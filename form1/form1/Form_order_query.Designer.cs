namespace form1
{
    partial class Form_order_query
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_order_query));
            this.Cb_order = new System.Windows.Forms.ComboBox();
            this.DV = new System.Windows.Forms.DataGridView();
            this.Button_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DV)).BeginInit();
            this.SuspendLayout();
            // 
            // Cb_order
            // 
            this.Cb_order.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_order.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Cb_order.FormattingEnabled = true;
            this.Cb_order.Location = new System.Drawing.Point(12, 12);
            this.Cb_order.Name = "Cb_order";
            this.Cb_order.Size = new System.Drawing.Size(604, 20);
            this.Cb_order.TabIndex = 0;
            this.Cb_order.SelectedIndexChanged += new System.EventHandler(this.Cb_order_SelectedIndexChanged);
            // 
            // DV
            // 
            this.DV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DV.Location = new System.Drawing.Point(12, 38);
            this.DV.Name = "DV";
            this.DV.ReadOnly = true;
            this.DV.RowTemplate.Height = 23;
            this.DV.Size = new System.Drawing.Size(646, 346);
            this.DV.TabIndex = 1;
            // 
            // Button_back
            // 
            this.Button_back.Location = new System.Drawing.Point(548, 390);
            this.Button_back.Name = "Button_back";
            this.Button_back.Size = new System.Drawing.Size(110, 38);
            this.Button_back.TabIndex = 2;
            this.Button_back.Text = "撤销订单";
            this.Button_back.UseVisualStyleBackColor = true;
            this.Button_back.Click += new System.EventHandler(this.Button_back_Click);
            // 
            // Form_userinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 440);
            this.Controls.Add(this.Button_back);
            this.Controls.Add(this.DV);
            this.Controls.Add(this.Cb_order);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_userinfo";
            this.Text = "订票记录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_userinfo_FormClosed);
            this.Load += new System.EventHandler(this.Form_userinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cb_order;
        private System.Windows.Forms.DataGridView DV;
        private System.Windows.Forms.Button Button_back;
    }
}