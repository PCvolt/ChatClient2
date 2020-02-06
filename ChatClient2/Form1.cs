using System;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Collections.Generic;

#region Data structures
[DataContract(Name = "MsgType")]
public enum MsgType
{
	[EnumMember] createprofile = 0,
	[EnumMember] login = 1,
	[EnumMember] listtopics = 2,
	[EnumMember] createtopic = 3,
	[EnumMember] listusers = 4,
	[EnumMember] sendmsg = 5,
	[EnumMember] sendprivmsg = 6,
	[EnumMember] switchtopic = 7,
	[EnumMember] help = 8
}

public struct Message
{
	public MsgType Mymsgtype { get; set; }
	public List<string> S { get; set; }
	public string Topic { get; set; }

	public Message(MsgType msgtype, List<string> listofString, string tpc = null)
	{
		this.Mymsgtype = msgtype;
		this.S = new List<string>(listofString);
		this.Topic = tpc;
	}
}

public struct Client
{
	public TcpClient s;
	public string username;
	public string topic;

	public Client(TcpClient client, string usn, string tpc = "#welcome")
	{
		this.s = client;
		this.username = usn;
		this.topic = tpc;
	}
};
#endregion

namespace ChatClient2
{
	public partial class Form1 : Form
	{
		TcpClient clientSocket = new TcpClient();
		NetworkStream serverStream = null;

		Client c = new Client();
		List<string> ls = new List<string>();
		Dictionary<string, string> backlogs = new Dictionary<string, string>();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int res = connect();
			if (res == 0)
			{
				msgBox.Focus();
				c.topic = "#welcome";
				updateChatBox("Client Started");
				label1.Text = "Connected to server.";
				serverStream = clientSocket.GetStream();
				ls.Add("");


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
					Message myMessage = receiveMessage(clientSocket);

					switch (myMessage.Mymsgtype)
					{
						case MsgType.sendmsg:
							{
								updateChatBox(myMessage.S[0]);
								
							}
							break;
						case MsgType.switchtopic:
							break;
						case MsgType.listtopics:
							updateTopics(myMessage.S);
							break;
						case MsgType.listusers:
							updateUserlist(myMessage.S);
							break;
						default:
							updateChatBox(myMessage.S[0]);
							break;
					}
				}
			}
			catch (IOException ignore) { }
			finally
			{
				clientSocket.Close();
			}
		}
		private void updateUserlist(List<string> S)
		{
			listChannels.Invoke(new Action(() => listUsers.Items.Clear()));
			foreach (string t in S)
				listChannels.Invoke(new Action(() => listUsers.Items.Add(t)));
		}

		private void updateTopics(List<string> S)
		{
			foreach (string t in S)
			{
				if (!backlogs.ContainsKey(t))
				{
					backlogs.Add(t, "");
				}
			}

			listChannels.Invoke(new Action(() => listChannels.Items.Clear()));
			foreach (string t in S)
			{
				listChannels.Invoke(new Action(() => listChannels.Items.Add(t)));
			}
		}

		private void updateChatBox(string message)
		{
			chatBox.Invoke(new Action(() => chatBox.Text += message + " " + Environment.NewLine));
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
			ls[0] = msgBox.Text.Trim();
			sendMessage(serverStream, new Message(parse(msgBox.Text), ls, c.topic));

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

		private void listChannels_MouseClick(object sender, MouseEventArgs e)
		{
			string index_s = this.listChannels.GetItemText(listChannels.SelectedItem);

			if (!index_s.Equals(""))
			{
				c.topic = index_s;
			}
		}
	}
}


/*
 * Disconnect properly
 * Hash password
 * list of channels not read in debug
 * DM (peer to peer ? Channel dédié et non joignable ?)
 * Logs (clear la console, renvoyer les X derniers messages))
*/
