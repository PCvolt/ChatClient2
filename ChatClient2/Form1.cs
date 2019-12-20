﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ProtoBuf;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json;

public struct Client
{
	public TcpClient s;
	public String username;
	public String topic;

	public Client(TcpClient client, String usn, String tpc)
	{
		this.s = client;
		this.username = usn;
		this.topic = tpc;
	}
};

[DataContract(Name = "MsgType")]
public enum MsgType
{
	[EnumMember] createprofile = 0,
	[EnumMember] login = 1,
	[EnumMember] listtopics = 2,
	[EnumMember] createtopic = 3,
	[EnumMember] jointopic = 4,
	[EnumMember] sendmsg = 5,
	[EnumMember] sendprivmsg = 6,
	[EnumMember] help = 7
}

[DataContract]
public struct Message
{
	[DataMember] public MsgType Mymsgtype { get; set; }
	[DataMember] public string S1 { get; set; }
	[DataMember] public string S2 { get; set; }

	public Message(MsgType msgtype, string s1, string s2)
	{
		this.Mymsgtype = msgtype;
		this.S1 = s1;
		this.S2 = s2;
	}
}

namespace ChatClient2
{
	public partial class Form1 : Form
	{
		TcpClient clientSocket = new TcpClient();
		NetworkStream serverStream = null;

		public Form1()
		{
			InitializeComponent();
			msgBox.Focus();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int res = connect();
			if (res == 0)
			{
				msgBox.Focus();
				updateChatBox("Client Started");
				label1.Text = "Connected to server.";
				serverStream = clientSocket.GetStream();


				Thread t = new Thread(readFromServer);
				t.IsBackground = true;
				t.Start();
			}
			else
			{
				Application.Exit();
			}
		}

		private int connect()
		{
			for (int i = 0; i < 20; ++i)
			{
				try
				{
					clientSocket.Connect("127.0.0.1", 8888);
					return 0;
				}
				catch (SocketException ignore)
				{
					updateChatBox("Retrying... (#" + i + ")");
					Thread.Sleep(2000);
				}
			}
			return 1;
		}

		static Message receiveMessage(TcpClient s)
		{
			NetworkStream ns = s.GetStream();
			byte[] bytesFrom = new byte[1024];
			ns.Read(bytesFrom, 0, bytesFrom.Length);
			Utf8JsonReader utf8Reader = new Utf8JsonReader(bytesFrom);

			return JsonSerializer.Deserialize<Message>(ref utf8Reader);
		}


		private void readFromServer()
		{
			try
			{
				while (true)
				{
					// Read data from server separately
					//MsgType returnType = (MsgType) Int32.Parse(readData(clientSocket));
					Message myMessage = receiveMessage(clientSocket);
					updateChatBox(myMessage.S1);
					/*
					switch ((MsgType) Int32.Parse(returndata))
					{
						case MsgType.listtopics:
							listChannels.Items.Clear();
							listChannels.Items.Add(returndata);
							break;

						default:
							updateChatBox(returndata);
							break;
					}*/
				}
			}
			catch (IOException ignore) { }
			finally
			{
				clientSocket.Close();
			}
		}

		private void updateChatBox(string message)
		{
			chatBox.Invoke(new Action(() => chatBox.Text += message + Environment.NewLine));
		}

		private MsgType parse(string message)
		{
			string firstWord = message.IndexOf(" ") > -1 ? message.Substring(0, message.IndexOf(" ")) : message;

			switch (firstWord)
			{
				case "/createtopic":
					return MsgType.createtopic;
				case "/listtopics":
					return MsgType.listtopics;
				case "/jointopic":
					return MsgType.jointopic;
				case "/sendprivmsg":
					return MsgType.sendprivmsg;
				case "/help":
					return MsgType.help;
				default:
					return MsgType.sendmsg;
			}
		}

		/* SENDING DATA FUNCTIONS */
		static void sendMessage(NetworkStream ns, Message myMessage)
		{
			Byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(myMessage);

			ns.Write(jsonUtf8Bytes, 0, jsonUtf8Bytes.Length);
		}

		/* EVENTS FOR SENDING DATA */
		private void sendButton_Click(object sender, EventArgs e)
		{
			// Write data to server
			sendMessage(serverStream, new Message(parse(msgBox.Text), msgBox.Text.Trim(), null));
			
			msgBox.Text = "";
			msgBox.Focus();
		}


		private void createProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CreateProfile createProfileForm = new CreateProfile(serverStream);
			createProfileForm.Show();
		}

		private void loginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Login createProfileForm = new Login(serverStream);
			createProfileForm.Show();
		}
	}
}

//check if the server is down