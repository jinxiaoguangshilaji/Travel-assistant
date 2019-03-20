using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace form1
{
    public partial class Form_order_query : bianliang
    {
        Form1 fa;
        DataTable dt = new DataTable();
        string[] valid ={"", "未取票", "已取票", "已过期", "已退票", "其他原因作废" };
        public Form_order_query()
        {
            InitializeComponent();
        }
        public Form_order_query(Form1 ls)
        {
            InitializeComponent();
            fa = ls;
        }
        private void Form_userinfo_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select order_id as \'id\',order_time as \'time\',order_cost as \'cost\' from order_form where user_id = \'"+Id+"\' order by order_time";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                myda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; ++i)
                    Cb_order.Items.Add("订单号:"+dt.Rows[i]["id"].ToString()+"  生成时间:"+ dt.Rows[i]["time"].ToString() +"  订单总额:"+ dt.Rows[i]["cost"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }

        private void Form_userinfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            doing = doing & ~16;
        }

        private void Button_back_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂不支持撤销");
        }

        private void Cb_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from order_info where order_id=\'" + dt.Rows[Cb_order.SelectedIndex]["id"].ToString() + "\'";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt2 = new DataTable();
                myda.Fill(dt2);
                dt2.Columns["order_id"].ColumnName = "订单号";
                dt2.Columns["traffic_id"].ColumnName = "车次号";
                dt2.Columns["traffic_start_time"].ColumnName = "出发时间";
                dt2.Columns["traffic_seat"].ColumnName = "座位号";
                dt2.Columns["traffic_cost"].ColumnName = "票价";
                dt2.Columns.Add("状态", typeof(string));
                for (int i = 0; i < dt2.Rows.Count; ++i)
                    dt2.Rows[i]["状态"] = valid[Convert.ToInt32(dt2.Rows[i]["order_valid"])];
                dt2.Columns.Remove("order_valid");
                DV.DataSource = dt2;
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }
    }
}
