using ProtoBuf;
using System;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;

namespace ChatClient2
{
	public partial class Login : Form
	{
		NetworkStream serverStream = null;

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
			sendMessage(serverStream, new Message(MsgType.login, usernameBox.Text.Trim(), passwordBox.Text.Trim()));

			this.Close();
		}
	}
}
