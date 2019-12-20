using ProtoBuf;
using System;
using System.Net.Sockets;
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
			Serializer.Serialize(ns, myMessage);
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			sendMessage(serverStream, new Message(MsgType.login, usernameBox.Text.Trim(), passwordBox.Text.Trim()));

			this.Close();
		}
	}
}
