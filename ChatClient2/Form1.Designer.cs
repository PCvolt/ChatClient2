namespace ChatClient2
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.chatBox = new System.Windows.Forms.TextBox();
			this.msgBox = new System.Windows.Forms.TextBox();
			this.sendButton = new System.Windows.Forms.Button();
			this.listChannels = new System.Windows.Forms.ListBox();
			this.listUsers = new System.Windows.Forms.ListBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(135, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// chatBox
			// 
			this.chatBox.BackColor = System.Drawing.SystemColors.Window;
			this.chatBox.Location = new System.Drawing.Point(138, 51);
			this.chatBox.Multiline = true;
			this.chatBox.Name = "chatBox";
			this.chatBox.ReadOnly = true;
			this.chatBox.Size = new System.Drawing.Size(670, 391);
			this.chatBox.TabIndex = 1;
			// 
			// msgBox
			// 
			this.msgBox.Location = new System.Drawing.Point(138, 448);
			this.msgBox.Name = "msgBox";
			this.msgBox.Size = new System.Drawing.Size(589, 20);
			this.msgBox.TabIndex = 2;
			// 
			// sendButton
			// 
			this.sendButton.Location = new System.Drawing.Point(733, 446);
			this.sendButton.Name = "sendButton";
			this.sendButton.Size = new System.Drawing.Size(75, 23);
			this.sendButton.TabIndex = 3;
			this.sendButton.Text = "Send";
			this.sendButton.UseVisualStyleBackColor = true;
			this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// listChannels
			// 
			this.listChannels.FormattingEnabled = true;
			this.listChannels.Location = new System.Drawing.Point(12, 51);
			this.listChannels.Name = "listChannels";
			this.listChannels.Size = new System.Drawing.Size(120, 199);
			this.listChannels.TabIndex = 4;
			this.listChannels.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listChannels_MouseClick);
			// 
			// listUsers
			// 
			this.listUsers.FormattingEnabled = true;
			this.listUsers.Location = new System.Drawing.Point(12, 256);
			this.listUsers.Name = "listUsers";
			this.listUsers.Size = new System.Drawing.Size(120, 186);
			this.listUsers.TabIndex = 5;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.creditsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(820, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createProfileToolStripMenuItem,
            this.loginToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// createProfileToolStripMenuItem
			// 
			this.createProfileToolStripMenuItem.Name = "createProfileToolStripMenuItem";
			this.createProfileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.createProfileToolStripMenuItem.Text = "Create Profile";
			this.createProfileToolStripMenuItem.Click += new System.EventHandler(this.createProfileToolStripMenuItem_Click);
			// 
			// loginToolStripMenuItem
			// 
			this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
			this.loginToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.loginToolStripMenuItem.Text = "Login";
			this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
			// 
			// creditsToolStripMenuItem
			// 
			this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
			this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.creditsToolStripMenuItem.Text = "Credits";
			// 
			// Form1
			// 
			this.AcceptButton = this.sendButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(820, 477);
			this.Controls.Add(this.listUsers);
			this.Controls.Add(this.listChannels);
			this.Controls.Add(this.sendButton);
			this.Controls.Add(this.msgBox);
			this.Controls.Add(this.chatBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox chatBox;
		private System.Windows.Forms.TextBox msgBox;
		private System.Windows.Forms.Button sendButton;
		private System.Windows.Forms.ListBox listChannels;
		private System.Windows.Forms.ListBox listUsers;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
	}
}

