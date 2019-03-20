namespace form1
{
	partial class Form_signin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_signin));
            this.Tb_id = new System.Windows.Forms.TextBox();
            this.Tb_nn = new System.Windows.Forms.TextBox();
            this.Tb_p = new System.Windows.Forms.TextBox();
            this.Tb_cp = new System.Windows.Forms.TextBox();
            this.Tb_ver = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lb_id = new System.Windows.Forms.Label();
            this.Lb_nn = new System.Windows.Forms.Label();
            this.Lb_p = new System.Windows.Forms.Label();
            this.Lb_cp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Tb_phone = new System.Windows.Forms.TextBox();
            this.Lb_phone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tb_id
            // 
            this.Tb_id.Location = new System.Drawing.Point(119, 32);
            this.Tb_id.Name = "Tb_id";
            this.Tb_id.Size = new System.Drawing.Size(172, 21);
            this.Tb_id.TabIndex = 0;
            this.Tb_id.WordWrap = false;
            this.Tb_id.Leave += new System.EventHandler(this.Tb_id_Leave);
            // 
            // Tb_nn
            // 
            this.Tb_nn.Location = new System.Drawing.Point(119, 84);
            this.Tb_nn.Name = "Tb_nn";
            this.Tb_nn.Size = new System.Drawing.Size(172, 21);
            this.Tb_nn.TabIndex = 1;
            this.Tb_nn.WordWrap = false;
            this.Tb_nn.Leave += new System.EventHandler(this.Tb_nn_Leave);
            // 
            // Tb_p
            // 
            this.Tb_p.Location = new System.Drawing.Point(119, 141);
            this.Tb_p.Name = "Tb_p";
            this.Tb_p.PasswordChar = '*';
            this.Tb_p.Size = new System.Drawing.Size(172, 21);
            this.Tb_p.TabIndex = 2;
            this.Tb_p.WordWrap = false;
            this.Tb_p.Leave += new System.EventHandler(this.Tb_p_Leave);
            // 
            // Tb_cp
            // 
            this.Tb_cp.Location = new System.Drawing.Point(119, 202);
            this.Tb_cp.Name = "Tb_cp";
            this.Tb_cp.PasswordChar = '*';
            this.Tb_cp.Size = new System.Drawing.Size(172, 21);
            this.Tb_cp.TabIndex = 3;
            this.Tb_cp.WordWrap = false;
            this.Tb_cp.Leave += new System.EventHandler(this.Tb_cp_Leave);
            // 
            // Tb_ver
            // 
            this.Tb_ver.Location = new System.Drawing.Point(119, 310);
            this.Tb_ver.Name = "Tb_ver";
            this.Tb_ver.Size = new System.Drawing.Size(129, 21);
            this.Tb_ver.TabIndex = 5;
            this.Tb_ver.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "nick name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "confirm password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "verification code";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(119, 337);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 33);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Lb_id
            // 
            this.Lb_id.AutoSize = true;
            this.Lb_id.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_id.Location = new System.Drawing.Point(117, 56);
            this.Lb_id.Name = "Lb_id";
            this.Lb_id.Size = new System.Drawing.Size(101, 12);
            this.Lb_id.TabIndex = 12;
            this.Lb_id.Text = "id已存在或不合法";
            this.Lb_id.Visible = false;
            // 
            // Lb_nn
            // 
            this.Lb_nn.AutoSize = true;
            this.Lb_nn.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_nn.Location = new System.Drawing.Point(117, 108);
            this.Lb_nn.Name = "Lb_nn";
            this.Lb_nn.Size = new System.Drawing.Size(65, 12);
            this.Lb_nn.TabIndex = 13;
            this.Lb_nn.Text = "昵称不合法";
            this.Lb_nn.Visible = false;
            // 
            // Lb_p
            // 
            this.Lb_p.AutoSize = true;
            this.Lb_p.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_p.Location = new System.Drawing.Point(117, 165);
            this.Lb_p.Name = "Lb_p";
            this.Lb_p.Size = new System.Drawing.Size(65, 12);
            this.Lb_p.TabIndex = 14;
            this.Lb_p.Text = "密码不合法";
            this.Lb_p.Visible = false;
            // 
            // Lb_cp
            // 
            this.Lb_cp.AutoSize = true;
            this.Lb_cp.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_cp.Location = new System.Drawing.Point(117, 226);
            this.Lb_cp.Name = "Lb_cp";
            this.Lb_cp.Size = new System.Drawing.Size(113, 12);
            this.Lb_cp.TabIndex = 15;
            this.Lb_cp.Text = "两次密码输入不一致";
            this.Lb_cp.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "phone";
            // 
            // Tb_phone
            // 
            this.Tb_phone.Location = new System.Drawing.Point(119, 266);
            this.Tb_phone.Name = "Tb_phone";
            this.Tb_phone.Size = new System.Drawing.Size(172, 21);
            this.Tb_phone.TabIndex = 4;
            this.Tb_phone.WordWrap = false;
            this.Tb_phone.Leave += new System.EventHandler(this.Tb_phone_Leave);
            // 
            // Lb_phone
            // 
            this.Lb_phone.AutoSize = true;
            this.Lb_phone.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_phone.Location = new System.Drawing.Point(117, 290);
            this.Lb_phone.Name = "Lb_phone";
            this.Lb_phone.Size = new System.Drawing.Size(89, 12);
            this.Lb_phone.TabIndex = 18;
            this.Lb_phone.Text = "联系方式不合法";
            this.Lb_phone.Visible = false;
            // 
            // Form_signin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 525);
            this.Controls.Add(this.Lb_phone);
            this.Controls.Add(this.Tb_phone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Lb_cp);
            this.Controls.Add(this.Lb_p);
            this.Controls.Add(this.Lb_nn);
            this.Controls.Add(this.Lb_id);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tb_ver);
            this.Controls.Add(this.Tb_cp);
            this.Controls.Add(this.Tb_p);
            this.Controls.Add(this.Tb_nn);
            this.Controls.Add(this.Tb_id);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_signin";
            this.Text = "注册账户";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_signin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox Tb_id;
		private System.Windows.Forms.TextBox Tb_nn;
		private System.Windows.Forms.TextBox Tb_p;
		private System.Windows.Forms.TextBox Tb_cp;
		private System.Windows.Forms.TextBox Tb_ver;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label Lb_id;
		private System.Windows.Forms.Label Lb_nn;
		private System.Windows.Forms.Label Lb_p;
		private System.Windows.Forms.Label Lb_cp;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox Tb_phone;
		private System.Windows.Forms.Label Lb_phone;
	}
}