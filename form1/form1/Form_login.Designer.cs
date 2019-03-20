namespace form1
{
    partial class Form_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_login));
            this.text_uid = new System.Windows.Forms.TextBox();
            this.text_pswd = new System.Windows.Forms.TextBox();
            this.text_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Button_signin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // text_uid
            // 
            this.text_uid.Location = new System.Drawing.Point(78, 27);
            this.text_uid.Name = "text_uid";
            this.text_uid.Size = new System.Drawing.Size(131, 21);
            this.text_uid.TabIndex = 0;
            this.text_uid.Text = "putong";
            // 
            // text_pswd
            // 
            this.text_pswd.Location = new System.Drawing.Point(78, 69);
            this.text_pswd.Name = "text_pswd";
            this.text_pswd.PasswordChar = '*';
            this.text_pswd.Size = new System.Drawing.Size(131, 21);
            this.text_pswd.TabIndex = 1;
            this.text_pswd.Text = "putong";
            // 
            // text_code
            // 
            this.text_code.Location = new System.Drawing.Point(78, 111);
            this.text_code.Name = "text_code";
            this.text_code.Size = new System.Drawing.Size(131, 21);
            this.text_code.TabIndex = 2;
            this.text_code.Text = "2333";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "验证码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 29);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Button_signin
            // 
            this.Button_signin.Location = new System.Drawing.Point(132, 182);
            this.Button_signin.Name = "Button_signin";
            this.Button_signin.Size = new System.Drawing.Size(77, 42);
            this.Button_signin.TabIndex = 8;
            this.Button_signin.Text = "注册";
            this.Button_signin.UseVisualStyleBackColor = true;
            this.Button_signin.Click += new System.EventHandler(this.Button_signin_Click);
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 259);
            this.Controls.Add(this.Button_signin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_code);
            this.Controls.Add(this.text_pswd);
            this.Controls.Add(this.text_uid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_login_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_uid;
        private System.Windows.Forms.TextBox text_pswd;
        private System.Windows.Forms.TextBox text_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button Button_signin;
	}
}