using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;

namespace ChatClient2
{
	public partial class Login : Form
	{
		NetworkStream serverStream = null;
		List<string> ls = new List<String>();

		public Login(NetworkStream ns)
		{
			InitializeComponent();
			serverStream = ns;
		}

		static void sendMessage(NetworkStream ns, Message myMessage)
		{
			Byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(myMessage);

			ns.Write(jsonUtf8Bytes, 0, jsonUtf8Bytes.Length);
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			ls[0] = usernameBox.Text.Trim();
			ls[1] = passwordBox.Text.Trim();
			sendMessage(serverStream, new Message(MsgType.login, ls));

			this.Close();
		}

		private void Login_Load(object sender, EventArgs e)
		{
			ls.Add("");
			ls.Add("");
		}
	}
}
