using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ChatClient2
{
	public partial class CreateProfile : Form
	{
		NetworkStream serverStream = null;

		public CreateProfile(NetworkStream ns)
		{
			InitializeComponent();
			serverStream = ns;
		}

		static void sendMessage(NetworkStream ns, Message myMessage)
		{
			Serializer.Serialize(ns, myMessage);
		}

		private void createProfileBtn_Click(object sender, EventArgs e)
		{
			sendMessage(serverStream, new Message(MsgType.login, usernameBox.Text.Trim(), passwordBox.Text.Trim()));

			this.Close();
		}
	}
}
