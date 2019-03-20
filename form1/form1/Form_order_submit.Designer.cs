namespace form1
{
    partial class Form_order_submit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_order_submit));
            this.Cb_start = new System.Windows.Forms.ComboBox();
            this.Cb_end = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Bt_add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Bt_submit = new System.Windows.Forms.Button();
            this.Cb_traffic = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lb_money = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cb_start
            // 
            this.Cb_start.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_start.FormattingEnabled = true;
            this.Cb_start.Location = new System.Drawing.Point(71, 33);
            this.Cb_start.Name = "Cb_start";
            this.Cb_start.Size = new System.Drawing.Size(167, 20);
            this.Cb_start.TabIndex = 0;
            this.Cb_start.SelectedIndexChanged += new System.EventHandler(this.Cb_start_SelectedIndexChanged);
            // 
            // Cb_end
            // 
            this.Cb_end.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_end.FormattingEnabled = true;
            this.Cb_end.Location = new System.Drawing.Point(267, 33);
            this.Cb_end.Name = "Cb_end";
            this.Cb_end.Size = new System.Drawing.Size(160, 20);
            this.Cb_end.TabIndex = 1;
            this.Cb_end.SelectedIndexChanged += new System.EventHandler(this.Cb_end_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "至";
            // 
            // Bt_add
            // 
            this.Bt_add.Location = new System.Drawing.Point(433, 49);
            this.Bt_add.Name = "Bt_add";
            this.Bt_add.Size = new System.Drawing.Size(67, 30);
            this.Bt_add.TabIndex = 3;
            this.Bt_add.Text = "加入订单";
            this.Bt_add.UseVisualStyleBackColor = true;
            this.Bt_add.Click += new System.EventHandler(this.Bt_add_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(413, 493);
            this.dataGridView1.TabIndex = 4;
            // 
            // Bt_submit
            // 
            this.Bt_submit.Location = new System.Drawing.Point(433, 545);
            this.Bt_submit.Name = "Bt_submit";
            this.Bt_submit.Size = new System.Drawing.Size(67, 33);
            this.Bt_submit.TabIndex = 5;
            this.Bt_submit.Text = "提交";
            this.Bt_submit.UseVisualStyleBackColor = true;
            this.Bt_submit.Click += new System.EventHandler(this.Bt_submit_Click);
            // 
            // Cb_traffic
            // 
            this.Cb_traffic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_traffic.FormattingEnabled = true;
            this.Cb_traffic.Location = new System.Drawing.Point(71, 59);
            this.Cb_traffic.Name = "Cb_traffic";
            this.Cb_traffic.Size = new System.Drawing.Size(356, 20);
            this.Cb_traffic.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "详细信息";
            // 
            // Lb_money
            // 
            this.Lb_money.AutoSize = true;
            this.Lb_money.Location = new System.Drawing.Point(12, 9);
            this.Lb_money.Name = "Lb_money";
            this.Lb_money.Size = new System.Drawing.Size(95, 12);
            this.Lb_money.TabIndex = 9;
            this.Lb_money.Text = "订单金额:0.00元";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "起止地点";
            // 
            // Form_order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 590);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Lb_money);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cb_traffic);
            this.Controls.Add(this.Bt_submit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Bt_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cb_end);
            this.Controls.Add(this.Cb_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成订单";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_order_FormClosed);
            this.Load += new System.EventHandler(this.Form_order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cb_start;
        private System.Windows.Forms.ComboBox Cb_end;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Bt_add;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Bt_submit;
		private System.Windows.Forms.ComboBox Cb_traffic;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label Lb_money;
        private System.Windows.Forms.Label label3;
    }
}