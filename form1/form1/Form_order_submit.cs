using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace form1
{
    public partial class Form_order_submit : bianliang
    {
        Form1 fa;
        double money_temp = 0;
		DataTable order;
        public Form_order_submit()
        {
            InitializeComponent();
        }
        public Form_order_submit(Form1 frm,DataTable dt)
        {
            InitializeComponent();
            fa = frm;
			fa.Fromwhere();
			if(fa.cb_best.SelectedIndex!=3)
			{
				order = dt.Copy();
			}
			else
			{
				order = new DataTable();
			}
        }
		private void Form_order_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			doing = doing & ~2;
		}
		private void Money_count()
		{
			money_temp = 0;
			for (int i = 0; i < order.Rows.Count; ++i)
				money_temp +=Convert.ToDouble(order.Rows[i]["票价"]);
			if (money_temp > money)
				Lb_money.ForeColor = Color.Red;
			else
				Lb_money.ForeColor = Color.Black;
			Lb_money.Text = "订单金额:" + money_temp.ToString() + "元";
		}
        private void Form_order_Load(object sender, EventArgs e)
        {
            try
            {
				dataGridView1.DataSource = order;
				Money_count();
				Cb_start.Items.Add("请选择出发地");
                Cb_start.SelectedIndex = 0;
                String sql1 = "select distinct traffic_start_point from(select *from traffic_plane union all select *from traffic_train union all select *from traffic_bus union all select *from traffic_hstrain)t where traffic_seat_number > traffic_seat_count";
                SqlDataAdapter myda = new SqlDataAdapter(sql1, conn);
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                for (int i = 0; i < dt.Rows.Count; ++i)
                    Cb_start.Items.Add(dt.Rows[i]["traffic_start_point"].ToString());
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("已录入系统的车/机票信息均无余票", "抱歉");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }

        private void Cb_start_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cb_end.Items.Clear();
            Cb_end.Items.Add("请选择目的地");
            Cb_end.SelectedIndex = 0;
            if (Cb_start.SelectedIndex == 0)
            {
                return;
            }
            try
            {
                String sql = "select distinct traffic_end_point from(select *from traffic_bus union all select *from traffic_plane union all select *from traffic_train union all select *from traffic_hstrain)t where traffic_seat_number > traffic_seat_count and traffic_start_point=\'" + Cb_start.SelectedItem.ToString() + "\'";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                for (int i = 0; i < dt.Rows.Count; ++i)
                    Cb_end.Items.Add(dt.Rows[i]["traffic_end_point"].ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }

        }

        private void Cb_end_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cb_traffic.Items.Clear();
            Cb_traffic.Items.Add("请选择出行时间及方式");
            Cb_traffic.SelectedIndex = 0;
            if (Cb_end.SelectedIndex == 0)
            {
                return;
            }
            try
            {
                String sql = "select distinct traffic_start_time,traffic_end_time,traffic_cost,traffic_id from(select *from traffic_bus union all select *from traffic_plane union all select *from traffic_train union all select *from traffic_hstrain)t where traffic_seat_number > traffic_seat_count and traffic_start_point=\'" + Cb_start.SelectedItem.ToString() + "\' and traffic_end_point=\'"+Cb_end.SelectedItem.ToString()+"\'";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                for (int i = 0; i < dt.Rows.Count; ++i)
                    Cb_traffic.Items.Add(dt.Rows[i]["traffic_start_time"].ToString()+"~"+dt.Rows[i]["traffic_end_time"].ToString()+",¥"+dt.Rows[i]["traffic_cost"].ToString()+",id:"+dt.Rows[i]["traffic_id"].ToString());
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("已录入系统的车/机票信息中无符合条件的余票", "抱歉");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }

        private void Bt_add_Click(object sender, EventArgs e)
        {
			try
			{
				string p = Cb_traffic.SelectedItem.ToString();
				string stime = p.Substring(0, p.IndexOf("~"));
				string tid = p.Substring(p.IndexOf("id:")+"id:".Length);
				string sql = "select" + selected + "from (select *from traffic_bus union all select *from traffic_plane union all select *from traffic_train union all select *from traffic_hstrain)t where traffic_id=\'" + tid + "\' and traffic_start_time=\'" + stime + "\' and traffic_seat_number > traffic_seat_count;";
				SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
				DataTable dt = new DataTable(); // 实例化数据表
				myda.Fill(dt); // 保存数据
				if(dt.Rows.Count==0)
				{
					MessageBox.Show("最后一张票刚刚被人抢走了", "抱歉");
					error_info = "选好票之后,添加之前没票了";
					Cb_start.SelectedIndex = 0;
					return;
				}
				if(order.Rows.Count==0)
				{
					order = dt.Copy();
					dataGridView1.DataSource = order;
				}
				else
				{
					order.ImportRow(dt.Rows[0]);
				}
				Money_count();
			}
			catch (Exception ex)
			{
				MessageBox.Show("错误信息：" + ex.Message, "出现错误");
			}
		}
        private void Bt_submit_Click(object sender, EventArgs e)
        {
			Money_count();
            if (money_temp > money)
            {
                MessageBox.Show("余额不足,请充值");
                error_info = "提交订单时余额不足";
                return;
            }
			Submit();
        }
		private void Submit()
		{
			try
			{
                string sql0 = "select count(*) from order_form where user_id=\'"+Id+"\';";
                DataTable befor1 = new DataTable();
                SqlDataAdapter my1 = new SqlDataAdapter(sql0, conn);
                my1.Fill(befor1);
                int befor2 = Convert.ToInt32(befor1.Rows[0][0]);
                string sql = "insert into order_cache values\n";
				for(int i=0;i<order.Rows.Count;++i)
				{
					sql += "(\'"+Id+"\',\'"+order.Rows[i]["车次号"].ToString()+"\',\'"+order.Rows[i]["出发时间"].ToString()+"\',"+ order.Rows[i]["票价"].ToString() + ")";
					if (i == order.Rows.Count - 1)
						sql += ";";
					else
						sql += ",\n";
				}
				SqlCommand myda = new SqlCommand(sql, conn);
				int a = myda.ExecuteNonQuery();
                my1 = new SqlDataAdapter(sql0, conn);
                befor1 = new DataTable();
                my1.Fill(befor1);

                if (befor2 == Convert.ToInt32(befor1.Rows[0][0]))
                {
                    MessageBox.Show("购票失败,请重试");
                    this.Close();
                }
                else
                {
                    money = money - money_temp;
                    fa.Newuser();
                    MessageBox.Show("购票成功,请及时取票");
                    this.Close();
                }
            }
			catch (Exception ex)
			{
				MessageBox.Show("错误信息：" + ex.Message, "出现错误");
			}
		}
	}
}
