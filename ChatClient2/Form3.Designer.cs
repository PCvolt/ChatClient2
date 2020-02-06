namespace ChatClient2
{
	partial class Login
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
			this.username = new System.Windows.Forms.Label();
			this.password = new System.Windows.Forms.Label();
			this.loginBtn = new System.Windows.Forms.Button();
			this.usernameBox = new System.Windows.Forms.TextBox();
			this.passwordBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// username
			// 
			this.username.AutoSize = true;
			this.username.Location = new System.Drawing.Point(50, 30);
			this.username.Name = "username";
			this.username.Size = new System.Drawing.Size(53, 13);
			this.username.TabIndex = 0;
			this.username.Text = "username";
			// 
			// password
			// 
			this.password.AutoSize = true;
			this.password.Location = new System.Drawing.Point(50, 60);
			this.password.Name = "password";
			this.password.Size = new System.Drawing.Size(52, 13);
			this.password.TabIndex = 1;
			this.password.Text = "password";
			// 
			// loginBtn
			// 
			this.loginBtn.Location = new System.Drawing.Point(109, 116);
			this.loginBtn.Name = "loginBtn";
			this.loginBtn.Size = new System.Drawing.Size(75, 23);
			this.loginBtn.TabIndex = 2;
			this.loginBtn.Text = "Login";
			this.loginBtn.UseVisualStyleBackColor = true;
			this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
			// 
			// usernameBox
			// 
			this.usernameBox.Location = new System.Drawing.Point(109, 30);
			this.usernameBox.Name = "usernameBox";
			this.usernameBox.Size = new System.Drawing.Size(100, 20);
			this.usernameBox.TabIndex = 3;
			// 
			// passwordBox
			// 
			this.passwordBox.Location = new System.Drawing.Point(109, 56);
			this.passwordBox.Name = "passwordBox";
			this.passwordBox.PasswordChar = '•';
			this.passwordBox.Size = new System.Drawing.Size(100, 20);
			this.passwordBox.TabIndex = 4;
			// 
			// Login
			// 
			this.AcceptButton = this.loginBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 151);
			this.Controls.Add(this.passwordBox);
			this.Controls.Add(this.usernameBox);
			this.Controls.Add(this.loginBtn);
			this.Controls.Add(this.password);
			this.Controls.Add(this.username);
			this.Name = "Login";
			this.Text = "Login";
			this.Load += new System.EventHandler(this.Login_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label username;
		private System.Windows.Forms.Label password;
		private System.Windows.Forms.Button loginBtn;
		private System.Windows.Forms.TextBox usernameBox;
		private System.Windows.Forms.TextBox passwordBox;
	}
}