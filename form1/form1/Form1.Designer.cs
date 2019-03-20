namespace form1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lb_name = new System.Windows.Forms.Label();
            this.LLb_login = new System.Windows.Forms.LinkLabel();
            this.label_money = new System.Windows.Forms.Label();
            this.cb_start = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_end = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_best = new System.Windows.Forms.ComboBox();
            this.button_query = new System.Windows.Forms.Button();
            this.button_order = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ck_bus = new System.Windows.Forms.CheckBox();
            this.ck_hstrain = new System.Windows.Forms.CheckBox();
            this.ck_train = new System.Windows.Forms.CheckBox();
            this.ck_plane = new System.Windows.Forms.CheckBox();
            this.Bt_realname = new System.Windows.Forms.Button();
            this.LLb_money = new System.Windows.Forms.LinkLabel();
            this.Bt_admin = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Tp_time = new System.Windows.Forms.DateTimePicker();
            this.Bt_order = new System.Windows.Forms.Button();
            this.Pb_pay = new System.Windows.Forms.PictureBox();
            this.Bt_pay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_pay)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(264, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(434, 490);
            this.dataGridView1.TabIndex = 0;
            // 
            // Lb_name
            // 
            this.Lb_name.AutoSize = true;
            this.Lb_name.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Lb_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Lb_name.Location = new System.Drawing.Point(12, 9);
            this.Lb_name.Name = "Lb_name";
            this.Lb_name.Size = new System.Drawing.Size(89, 12);
            this.Lb_name.TabIndex = 2;
            this.Lb_name.Text = "当前用户: 游客";
            this.Lb_name.Click += new System.EventHandler(this.Label_name_Click);
            this.Lb_name.MouseEnter += new System.EventHandler(this.Label_name_MouseEnter);
            this.Lb_name.MouseLeave += new System.EventHandler(this.Label_name_MouseLeave);
            // 
            // LLb_login
            // 
            this.LLb_login.AutoSize = true;
            this.LLb_login.Location = new System.Drawing.Point(137, 9);
            this.LLb_login.Name = "LLb_login";
            this.LLb_login.Size = new System.Drawing.Size(53, 12);
            this.LLb_login.TabIndex = 3;
            this.LLb_login.TabStop = true;
            this.LLb_login.Text = "更换用户";
            this.LLb_login.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Linklogin_LinkClicked);
            // 
            // label_money
            // 
            this.label_money.AutoSize = true;
            this.label_money.Location = new System.Drawing.Point(12, 31);
            this.label_money.Name = "label_money";
            this.label_money.Size = new System.Drawing.Size(95, 12);
            this.label_money.TabIndex = 4;
            this.label_money.Text = "账户余额:0.00元";
            // 
            // cb_start
            // 
            this.cb_start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_start.FormattingEnabled = true;
            this.cb_start.Location = new System.Drawing.Point(71, 119);
            this.cb_start.Name = "cb_start";
            this.cb_start.Size = new System.Drawing.Size(160, 20);
            this.cb_start.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "出发地点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "目的地点";
            // 
            // cb_end
            // 
            this.cb_end.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_end.FormattingEnabled = true;
            this.cb_end.Location = new System.Drawing.Point(71, 154);
            this.cb_end.Name = "cb_end";
            this.cb_end.Size = new System.Drawing.Size(160, 20);
            this.cb_end.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "筛选条件";
            // 
            // cb_best
            // 
            this.cb_best.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_best.FormattingEnabled = true;
            this.cb_best.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cb_best.Items.AddRange(new object[] {
            "时间最短",
            "花费最小",
            "换乘最少",
            "一站直达"});
            this.cb_best.Location = new System.Drawing.Point(71, 218);
            this.cb_best.Name = "cb_best";
            this.cb_best.Size = new System.Drawing.Size(160, 20);
            this.cb_best.TabIndex = 8;
            // 
            // button_query
            // 
            this.button_query.Location = new System.Drawing.Point(46, 356);
            this.button_query.Name = "button_query";
            this.button_query.Size = new System.Drawing.Size(76, 30);
            this.button_query.TabIndex = 13;
            this.button_query.Text = "查询路线";
            this.button_query.UseVisualStyleBackColor = true;
            this.button_query.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button_order
            // 
            this.button_order.Location = new System.Drawing.Point(140, 356);
            this.button_order.Name = "button_order";
            this.button_order.Size = new System.Drawing.Size(82, 29);
            this.button_order.TabIndex = 14;
            this.button_order.Text = "生成订单";
            this.button_order.UseVisualStyleBackColor = true;
            this.button_order.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "选择交通方式";
            // 
            // ck_bus
            // 
            this.ck_bus.AutoSize = true;
            this.ck_bus.Checked = true;
            this.ck_bus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_bus.Location = new System.Drawing.Point(112, 255);
            this.ck_bus.Name = "ck_bus";
            this.ck_bus.Size = new System.Drawing.Size(48, 16);
            this.ck_bus.TabIndex = 9;
            this.ck_bus.Text = "大巴";
            this.ck_bus.UseVisualStyleBackColor = true;
            // 
            // ck_hstrain
            // 
            this.ck_hstrain.AutoSize = true;
            this.ck_hstrain.Checked = true;
            this.ck_hstrain.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_hstrain.Location = new System.Drawing.Point(112, 299);
            this.ck_hstrain.Name = "ck_hstrain";
            this.ck_hstrain.Size = new System.Drawing.Size(48, 16);
            this.ck_hstrain.TabIndex = 11;
            this.ck_hstrain.Text = "高铁";
            this.ck_hstrain.UseVisualStyleBackColor = true;
            // 
            // ck_train
            // 
            this.ck_train.AutoSize = true;
            this.ck_train.Checked = true;
            this.ck_train.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_train.Location = new System.Drawing.Point(112, 321);
            this.ck_train.Name = "ck_train";
            this.ck_train.Size = new System.Drawing.Size(48, 16);
            this.ck_train.TabIndex = 12;
            this.ck_train.Text = "火车";
            this.ck_train.UseVisualStyleBackColor = true;
            // 
            // ck_plane
            // 
            this.ck_plane.AutoSize = true;
            this.ck_plane.Checked = true;
            this.ck_plane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_plane.Location = new System.Drawing.Point(112, 277);
            this.ck_plane.Name = "ck_plane";
            this.ck_plane.Size = new System.Drawing.Size(48, 16);
            this.ck_plane.TabIndex = 10;
            this.ck_plane.Text = "飞机";
            this.ck_plane.UseVisualStyleBackColor = true;
            // 
            // Bt_realname
            // 
            this.Bt_realname.Location = new System.Drawing.Point(196, 6);
            this.Bt_realname.Name = "Bt_realname";
            this.Bt_realname.Size = new System.Drawing.Size(62, 29);
            this.Bt_realname.TabIndex = 19;
            this.Bt_realname.Text = "实名认证";
            this.Bt_realname.UseVisualStyleBackColor = true;
            this.Bt_realname.Visible = false;
            this.Bt_realname.Click += new System.EventHandler(this.Button_realname_Click);
            // 
            // LLb_money
            // 
            this.LLb_money.AutoSize = true;
            this.LLb_money.Location = new System.Drawing.Point(138, 31);
            this.LLb_money.Name = "LLb_money";
            this.LLb_money.Size = new System.Drawing.Size(29, 12);
            this.LLb_money.TabIndex = 21;
            this.LLb_money.TabStop = true;
            this.LLb_money.Text = "充值";
            this.LLb_money.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_money_LinkClicked);
            // 
            // Bt_admin
            // 
            this.Bt_admin.Location = new System.Drawing.Point(196, 6);
            this.Bt_admin.Name = "Bt_admin";
            this.Bt_admin.Size = new System.Drawing.Size(62, 29);
            this.Bt_admin.TabIndex = 22;
            this.Bt_admin.Text = "命令行";
            this.Bt_admin.UseVisualStyleBackColor = true;
            this.Bt_admin.Visible = false;
            this.Bt_admin.Click += new System.EventHandler(this.Bt_admin_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "出发时间";
            // 
            // Tp_time
            // 
            this.Tp_time.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.Tp_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Tp_time.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Tp_time.Location = new System.Drawing.Point(71, 186);
            this.Tp_time.Name = "Tp_time";
            this.Tp_time.Size = new System.Drawing.Size(160, 21);
            this.Tp_time.TabIndex = 7;
            this.Tp_time.Value = new System.DateTime(2017, 12, 13, 2, 59, 19, 0);
            // 
            // Bt_order
            // 
            this.Bt_order.Location = new System.Drawing.Point(196, 6);
            this.Bt_order.Name = "Bt_order";
            this.Bt_order.Size = new System.Drawing.Size(62, 30);
            this.Bt_order.TabIndex = 24;
            this.Bt_order.Text = "我的订单";
            this.Bt_order.UseVisualStyleBackColor = true;
            this.Bt_order.Visible = false;
            this.Bt_order.Click += new System.EventHandler(this.Bt_order_clicked);
            // 
            // Pb_pay
            // 
            this.Pb_pay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Pb_pay.Image = ((System.Drawing.Image)(resources.GetObject("Pb_pay.Image")));
            this.Pb_pay.Location = new System.Drawing.Point(12, 0);
            this.Pb_pay.Name = "Pb_pay";
            this.Pb_pay.Size = new System.Drawing.Size(361, 490);
            this.Pb_pay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pb_pay.TabIndex = 25;
            this.Pb_pay.TabStop = false;
            this.Pb_pay.Visible = false;
            // 
            // Bt_pay
            // 
            this.Bt_pay.Location = new System.Drawing.Point(379, 419);
            this.Bt_pay.Name = "Bt_pay";
            this.Bt_pay.Size = new System.Drawing.Size(102, 61);
            this.Bt_pay.TabIndex = 26;
            this.Bt_pay.Text = "我已付款";
            this.Bt_pay.UseVisualStyleBackColor = true;
            this.Bt_pay.Visible = false;
            this.Bt_pay.Click += new System.EventHandler(this.Bt_pay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 492);
            this.Controls.Add(this.Bt_pay);
            this.Controls.Add(this.Pb_pay);
            this.Controls.Add(this.Bt_order);
            this.Controls.Add(this.Tp_time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Bt_admin);
            this.Controls.Add(this.LLb_money);
            this.Controls.Add(this.Bt_realname);
            this.Controls.Add(this.ck_plane);
            this.Controls.Add(this.ck_train);
            this.Controls.Add(this.ck_hstrain);
            this.Controls.Add(this.ck_bus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_order);
            this.Controls.Add(this.button_query);
            this.Controls.Add(this.cb_best);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_end);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_start);
            this.Controls.Add(this.label_money);
            this.Controls.Add(this.LLb_login);
            this.Controls.Add(this.Lb_name);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客运票务管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_pay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Lb_name;
        private System.Windows.Forms.LinkLabel LLb_login;
        private System.Windows.Forms.Label label_money;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_query;
        private System.Windows.Forms.Button button_order;
        public System.Windows.Forms.ComboBox cb_start;
        public System.Windows.Forms.ComboBox cb_end;
        public System.Windows.Forms.ComboBox cb_best;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox ck_bus;
        public System.Windows.Forms.CheckBox ck_hstrain;
        public System.Windows.Forms.CheckBox ck_train;
        public System.Windows.Forms.CheckBox ck_plane;
        private System.Windows.Forms.Button Bt_realname;
		private System.Windows.Forms.LinkLabel LLb_money;
        private System.Windows.Forms.Button Bt_admin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker Tp_time;
		private System.Windows.Forms.Button Bt_order;
        private System.Windows.Forms.PictureBox Pb_pay;
        private System.Windows.Forms.Button Bt_pay;
    }
}

