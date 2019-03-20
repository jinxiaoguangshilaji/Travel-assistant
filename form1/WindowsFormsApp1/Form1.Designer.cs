namespace WindowsFormsApp1
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
            this.Bt_bk = new System.Windows.Forms.Button();
            this.Bt_st = new System.Windows.Forms.Button();
            this.Bt_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Bt_bk
            // 
            this.Bt_bk.Location = new System.Drawing.Point(12, 43);
            this.Bt_bk.Name = "Bt_bk";
            this.Bt_bk.Size = new System.Drawing.Size(120, 67);
            this.Bt_bk.TabIndex = 0;
            this.Bt_bk.Text = "备份";
            this.Bt_bk.UseVisualStyleBackColor = true;
            this.Bt_bk.Click += new System.EventHandler(this.Bt_bk_Click);
            // 
            // Bt_st
            // 
            this.Bt_st.Enabled = false;
            this.Bt_st.Location = new System.Drawing.Point(205, 43);
            this.Bt_st.Name = "Bt_st";
            this.Bt_st.Size = new System.Drawing.Size(120, 67);
            this.Bt_st.TabIndex = 1;
            this.Bt_st.Text = "恢复";
            this.Bt_st.UseVisualStyleBackColor = true;
            this.Bt_st.Click += new System.EventHandler(this.Bt_st_Click);
            // 
            // Bt_delete
            // 
            this.Bt_delete.Location = new System.Drawing.Point(383, 43);
            this.Bt_delete.Name = "Bt_delete";
            this.Bt_delete.Size = new System.Drawing.Size(120, 67);
            this.Bt_delete.TabIndex = 2;
            this.Bt_delete.Text = "删除";
            this.Bt_delete.UseVisualStyleBackColor = true;
            this.Bt_delete.Click += new System.EventHandler(this.Bt_delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 183);
            this.Controls.Add(this.Bt_delete);
            this.Controls.Add(this.Bt_st);
            this.Controls.Add(this.Bt_bk);
            this.Name = "Form1";
            this.Text = "数据库文件管理      -数据无价,谨慎操作";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Bt_bk;
        private System.Windows.Forms.Button Bt_st;
        private System.Windows.Forms.Button Bt_delete;
    }
}

