namespace ChatClient2
{
	partial class CreateProfile
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
			this.usernameBox = new System.Windows.Forms.TextBox();
			this.passwordBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.createProfileBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// usernameBox
			// 
			this.usernameBox.Location = new System.Drawing.Point(109, 27);
			this.usernameBox.Name = "usernameBox";
			this.usernameBox.Size = new System.Drawing.Size(100, 20);
			this.usernameBox.TabIndex = 0;
			// 
			// passwordBox
			// 
			this.passwordBox.Location = new System.Drawing.Point(109, 57);
			this.passwordBox.Name = "passwordBox";
			this.passwordBox.PasswordChar = '•';
			this.passwordBox.Size = new System.Drawing.Size(100, 20);
			this.passwordBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "username";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(50, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "password";
			// 
			// createProfileBtn
			// 
			this.createProfileBtn.Location = new System.Drawing.Point(109, 116);
			this.createProfileBtn.Name = "createProfileBtn";
			this.createProfileBtn.Size = new System.Drawing.Size(75, 23);
			this.createProfileBtn.TabIndex = 4;
			this.createProfileBtn.Text = "Create";
			this.createProfileBtn.UseVisualStyleBackColor = true;
			this.createProfileBtn.Click += new System.EventHandler(this.createProfileBtn_Click);
			// 
			// CreateProfile
			// 
			this.AcceptButton = this.createProfileBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 151);
			this.Controls.Add(this.createProfileBtn);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.passwordBox);
			this.Controls.Add(this.usernameBox);
			this.Name = "CreateProfile";
			this.Text = "Create Profile";
			this.Load += new System.EventHandler(this.CreateProfile_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox usernameBox;
		private System.Windows.Forms.TextBox passwordBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button createProfileBtn;
	}
}