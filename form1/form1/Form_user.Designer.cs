namespace form1
{
    partial class Form_user
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_user));
            this.Lb_phone = new System.Windows.Forms.Label();
            this.Tb_phone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Lb_cp = new System.Windows.Forms.Label();
            this.Lb_p = new System.Windows.Forms.Label();
            this.Lb_nn = new System.Windows.Forms.Label();
            this.Lb_id = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Bt_submit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Tb_ver = new System.Windows.Forms.TextBox();
            this.Tb_cp = new System.Windows.Forms.TextBox();
            this.Tb_p = new System.Windows.Forms.TextBox();
            this.Tb_nn = new System.Windows.Forms.TextBox();
            this.Tb_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Tb_op = new System.Windows.Forms.TextBox();
            this.Lb_op = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lb_phone
            // 
            this.Lb_phone.AutoSize = true;
            this.Lb_phone.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_phone.Location = new System.Drawing.Point(118, 289);
            this.Lb_phone.Name = "Lb_phone";
            this.Lb_phone.Size = new System.Drawing.Size(89, 12);
            this.Lb_phone.TabIndex = 37;
            this.Lb_phone.Text = "联系方式不合法";
            this.Lb_phone.Visible = false;
            // 
            // Tb_phone
            // 
            this.Tb_phone.Location = new System.Drawing.Point(120, 265);
            this.Tb_phone.Name = "Tb_phone";
            this.Tb_phone.Size = new System.Drawing.Size(172, 21);
            this.Tb_phone.TabIndex = 5;
            this.Tb_phone.WordWrap = false;
            this.Tb_phone.Leave += new System.EventHandler(this.Tb_phone_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 36;
            this.label6.Text = "phone";
            // 
            // Lb_cp
            // 
            this.Lb_cp.AutoSize = true;
            this.Lb_cp.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_cp.Location = new System.Drawing.Point(118, 235);
            this.Lb_cp.Name = "Lb_cp";
            this.Lb_cp.Size = new System.Drawing.Size(113, 12);
            this.Lb_cp.TabIndex = 35;
            this.Lb_cp.Text = "两次密码输入不一致";
            this.Lb_cp.Visible = false;
            // 
            // Lb_p
            // 
            this.Lb_p.AutoSize = true;
            this.Lb_p.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_p.Location = new System.Drawing.Point(118, 183);
            this.Lb_p.Name = "Lb_p";
            this.Lb_p.Size = new System.Drawing.Size(65, 12);
            this.Lb_p.TabIndex = 34;
            this.Lb_p.Text = "密码不合法";
            this.Lb_p.Visible = false;
            // 
            // Lb_nn
            // 
            this.Lb_nn.AutoSize = true;
            this.Lb_nn.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_nn.Location = new System.Drawing.Point(118, 85);
            this.Lb_nn.Name = "Lb_nn";
            this.Lb_nn.Size = new System.Drawing.Size(65, 12);
            this.Lb_nn.TabIndex = 33;
            this.Lb_nn.Text = "昵称不合法";
            this.Lb_nn.Visible = false;
            // 
            // Lb_id
            // 
            this.Lb_id.AutoSize = true;
            this.Lb_id.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_id.Location = new System.Drawing.Point(118, 33);
            this.Lb_id.Name = "Lb_id";
            this.Lb_id.Size = new System.Drawing.Size(101, 12);
            this.Lb_id.TabIndex = 32;
            this.Lb_id.Text = "id已存在或不合法";
            this.Lb_id.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(120, 342);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 33);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // Bt_submit
            // 
            this.Bt_submit.Location = new System.Drawing.Point(120, 389);
            this.Bt_submit.Name = "Bt_submit";
            this.Bt_submit.Size = new System.Drawing.Size(79, 35);
            this.Bt_submit.TabIndex = 7;
            this.Bt_submit.Text = "提交";
            this.Bt_submit.UseVisualStyleBackColor = true;
            this.Bt_submit.Click += new System.EventHandler(this.Bt_submit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "verification code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "confirm password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "new password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "nick name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "id";
            // 
            // Tb_ver
            // 
            this.Tb_ver.Location = new System.Drawing.Point(120, 315);
            this.Tb_ver.Name = "Tb_ver";
            this.Tb_ver.Size = new System.Drawing.Size(129, 21);
            this.Tb_ver.TabIndex = 6;
            this.Tb_ver.WordWrap = false;
            // 
            // Tb_cp
            // 
            this.Tb_cp.Location = new System.Drawing.Point(120, 211);
            this.Tb_cp.Name = "Tb_cp";
            this.Tb_cp.PasswordChar = '*';
            this.Tb_cp.Size = new System.Drawing.Size(172, 21);
            this.Tb_cp.TabIndex = 4;
            this.Tb_cp.WordWrap = false;
            this.Tb_cp.Leave += new System.EventHandler(this.Tb_cp_Leave);
            // 
            // Tb_p
            // 
            this.Tb_p.Location = new System.Drawing.Point(120, 159);
            this.Tb_p.Name = "Tb_p";
            this.Tb_p.PasswordChar = '*';
            this.Tb_p.Size = new System.Drawing.Size(172, 21);
            this.Tb_p.TabIndex = 3;
            this.Tb_p.WordWrap = false;
            this.Tb_p.Leave += new System.EventHandler(this.Tb_p_Leave);
            // 
            // Tb_nn
            // 
            this.Tb_nn.Location = new System.Drawing.Point(120, 61);
            this.Tb_nn.Name = "Tb_nn";
            this.Tb_nn.Size = new System.Drawing.Size(172, 21);
            this.Tb_nn.TabIndex = 1;
            this.Tb_nn.WordWrap = false;
            this.Tb_nn.Leave += new System.EventHandler(this.Tb_nn_Leave);
            // 
            // Tb_id
            // 
            this.Tb_id.CausesValidation = false;
            this.Tb_id.Location = new System.Drawing.Point(120, 9);
            this.Tb_id.Name = "Tb_id";
            this.Tb_id.ReadOnly = true;
            this.Tb_id.Size = new System.Drawing.Size(172, 21);
            this.Tb_id.TabIndex = 19;
            this.Tb_id.WordWrap = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "old password";
            // 
            // Tb_op
            // 
            this.Tb_op.Location = new System.Drawing.Point(120, 112);
            this.Tb_op.Name = "Tb_op";
            this.Tb_op.PasswordChar = '*';
            this.Tb_op.Size = new System.Drawing.Size(172, 21);
            this.Tb_op.TabIndex = 2;
            this.Tb_op.WordWrap = false;
            this.Tb_op.Leave += new System.EventHandler(this.Tb_op_Leave);
            // 
            // Lb_op
            // 
            this.Lb_op.AutoSize = true;
            this.Lb_op.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lb_op.Location = new System.Drawing.Point(118, 136);
            this.Lb_op.Name = "Lb_op";
            this.Lb_op.Size = new System.Drawing.Size(101, 12);
            this.Lb_op.TabIndex = 40;
            this.Lb_op.Text = "当前密码不可为空";
            this.Lb_op.Visible = false;
            // 
            // Form_user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 445);
            this.Controls.Add(this.Lb_op);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Tb_op);
            this.Controls.Add(this.Lb_phone);
            this.Controls.Add(this.Tb_phone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Lb_cp);
            this.Controls.Add(this.Lb_p);
            this.Controls.Add(this.Lb_nn);
            this.Controls.Add(this.Lb_id);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Bt_submit);
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
            this.Name = "Form_user";
            this.Text = "修改个人信息";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_user_FormClosed);
            this.Load += new System.EventHandler(this.Form_user_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lb_phone;
        private System.Windows.Forms.TextBox Tb_phone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Lb_cp;
        private System.Windows.Forms.Label Lb_p;
        private System.Windows.Forms.Label Lb_nn;
        private System.Windows.Forms.Label Lb_id;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Bt_submit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tb_ver;
        private System.Windows.Forms.TextBox Tb_cp;
        private System.Windows.Forms.TextBox Tb_p;
        private System.Windows.Forms.TextBox Tb_nn;
        private System.Windows.Forms.TextBox Tb_id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Tb_op;
        private System.Windows.Forms.Label Lb_op;
    }
}