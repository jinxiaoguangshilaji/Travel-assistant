using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.ServiceProcess;
namespace form1
{
    public partial class Form1 : bianliang
    {
		DataTable dt_son=new DataTable();
        ToolTip tip = new ToolTip();
        public string Fromwhere()
        {
            string sql = " ( ";
            int cont = 0;
            if (ck_bus.Checked)
            {
                sql += "select*from traffic_bus ";
                cont++;
            }
            if (ck_plane.Checked)
            {
                if (cont > 0)
                    sql += "union all ";
                sql += "select*from traffic_plane ";
                cont++;
            }
            if (ck_train.Checked)
            {
                if (cont > 0)
                    sql += "union all ";
                sql += "select*from traffic_train ";
                cont++;
            }
            if (ck_hstrain.Checked)
            {
                if (cont > 0)
                    sql += "union all ";
                sql += "select*from traffic_hstrain ";
                cont++;
            }
            sql += ")t ";
			selected2 = sql;
            return sql;
        }
        public void Dij(string start,string end,string time,int best)
        {
			//0:最快 1:最省钱 2:换乘最少 3:直达
			//     MessageBox.Show(start + "\n" + end+"\n"+best.ToString());
			/*
			 Number
			 Starting point
			 Start time
			 Destination
			 Arrival time
			 Price
			 */
			try
			{
				string sql;
				switch (best)
				{
					case 0:
					case 1:
					case 2:
						sql = "select count(*) as \'count\' from dij_ans";
						SqlDataAdapter myda1 = new SqlDataAdapter(sql, conn);
						DataTable dt1 = new DataTable(); // 实例化数据表
						myda1.Fill(dt1); // 保存数据
						if(Convert.ToInt32(dt1.Rows[0]["count"])!=0)
						{
							MessageBox.Show("排队中,请稍后再试,若长时间出现此提示,请联系管理员");
							error_info = "dij被占用";
							return;
						}
                        int traffic_flag = 1<<best;
                        if (ck_bus.Checked)
                            traffic_flag += 8;
                        if (ck_train.Checked)
                            traffic_flag += 16;
                        if (ck_hstrain.Checked)
                            traffic_flag += 32;
                        if (ck_plane.Checked)
                            traffic_flag += 64;
                        sql = "declare @starttime datetime;" +
								"set @starttime = \'" + time + "\';" +
								"exec dij \'"+start+"\',\'"+time+"\',\'"+end+"\',"+traffic_flag.ToString()+";"+
								"select "+selected+" from " + Fromwhere()+",dij_ans where t.traffic_id=dij_ans.id and t.traffic_end_time=dij_ans.end_time order by t.traffic_start_time;";
						break;
					default:
						sql = "select "+selected+" from "+Fromwhere()+ " where datediff(mi, \'"+time+ "\', traffic_start_time) >= 5 and traffic_seat_count<traffic_seat_number and traffic_start_point=\'"+start+"\' and traffic_end_point=\'"+end+"\' order by t.traffic_start_time;";
						break;
				}
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
				SqlCommand mycmd = new SqlCommand("delete from dij_ans;", conn);
				int a = mycmd.ExecuteNonQuery();
				if (best!=3)
				{
					DataTable dt2 = dt.Copy();
					dt2.Clear();
					string now = end;
					for(int i=dt.Rows.Count-1;i>=0;--i)
					{
						if (now == start)
							break;
						if(dt.Rows[i]["终点"].ToString()==now)
						{
							dt2.Rows.Add(dt.Rows[i].ItemArray);
							now = dt.Rows[i]["起点"].ToString();
						}
					}
					dt.Clear();
					for(int i=dt2.Rows.Count-1;i>=0;--i)
					{
						dt.Rows.Add(dt2.Rows[i].ItemArray);
					}
				}
                dataGridView1.DataSource = dt;
				dt_son=dt;
				if(dt.Rows.Count==0)
					MessageBox.Show("已录入系统的车/机票信息中无符合条件的余票", "抱歉");
			}
			catch (Exception ex)
			{
				MessageBox.Show("错误信息：" + ex.Message, "出现错误");
			}
		}
        public Form1()
        {
            InitializeComponent();
        }
        public void Newuser()
        {
            if(!Id.Equals(""))
                Lb_name.Cursor = Cursors.Hand;
            else
			{
				Lb_name.Cursor = Cursors.Arrow;
				tip.Hide(Lb_name);
			}
            Bt_realname.Visible = false;
            Bt_admin.Visible = false;
            Bt_order.Visible = false;
			Lb_name.Text = "当前用户: "+nickname.TrimEnd();
            label_money.Text = "账户余额: " + money.ToString() + "元";
			if ((userpower & 1) == 0 ||Id.Equals(""))
				return;
            if ((userpower & 6) == 0 && !Id.Equals(""))
                Bt_realname.Visible = true;
            else if ((userpower & 2) != 0)
                Bt_order.Visible = true;
			else if((userpower & 4) != 0)
				Bt_admin.Visible = true;
		}
        private void Form1_Load(object sender, EventArgs e)
        {
            Newuser();
			try
			{
				ServiceController[] ser = ServiceController.GetServices();
				foreach (ServiceController s in ser)
				{
					if (s.DisplayName.Length > 12)
						if (s.DisplayName.Substring(0, 12).Equals("SQL Server ("))
						{
							dbservername = s.ServiceName;
							if (s.Status == ServiceControllerStatus.Stopped)
							{
								s.Start();
                                s.WaitForStatus(ServiceControllerStatus.Running);
                                MessageBox.Show("SQL数据库服务启动成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show("SQL服务已开启");
							}
						}
				}
				if(dbservername.Equals(""))
				{
					MessageBox.Show("未找到名为SQL Server的服务,请检查是否安装了MSSQL");
					this.Close();
				}
			}
			catch
			{
				MessageBox.Show("sql服务启动失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}

            Tp_time.Value = DateTime.Now;

            try
            {
                conadminsql = "server=.;integrated security=SSPI;Connect Timeout=30";
                conadmin = new SqlConnection();
                conadmin.ConnectionString = conadminsql;
                conadmin.Open();

                string fileexist = AppDomain.CurrentDomain.BaseDirectory + iniio.GetValue("sql", "databasename") + ".mdf";
                if (!System.IO.File.Exists(fileexist))
                    try
                    {
                        MessageBox.Show("检测到目录下无数据库文件,稍后将尝试初始化数据库");
                        string text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "init.sql", System.Text.Encoding.GetEncoding("gb2312"));
                        text=text.Replace("@DATABASENAME", iniio.GetValue("sql", "databasename"));
                        text=text.Replace("@RUNDIRECTORY", AppDomain.CurrentDomain.BaseDirectory);
                        string[] queryArray = System.Text.RegularExpressions.Regex.Split(text, "GO", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        foreach(string i in queryArray)
                        {
                            SqlCommand mcmd = new SqlCommand(i, conadmin);
                            mcmd.ExecuteNonQuery();
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("错误信息：" + ex.Message, "出现错误");
                        this.Close();
                    }
                else
                    try
                    {
                        string database = "" +
                            "create database "+iniio.GetValue("sql","databasename")+" on" +
                            "(filename=\'" + AppDomain.CurrentDomain.BaseDirectory + iniio.GetValue("sql", "databasename") + ".mdf\')," +
                            "(filename=\'" + AppDomain.CurrentDomain.BaseDirectory + iniio.GetValue("sql", "databasename") + "_log.ldf\')" +
                            " for attach";
                        SqlCommand mcmd = new SqlCommand(database, conadmin);
                        mcmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    { }
                try
                {
                    string createuser = "create login " + iniio.GetValue("sql", "databasename") + "server with password=\'trafficserver\',default_database=" + iniio.GetValue("sql", "databasename") + ";";
                    SqlCommand mcmd = new SqlCommand(createuser, conadmin);
                    mcmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                { }
                try
                {
                    string createuser = "use "+iniio.GetValue("sql","databasename")+";";
                    SqlCommand mcmd = new SqlCommand(createuser, conadmin);
                    mcmd.ExecuteNonQuery();
                    createuser = "" +
                        "create user " + iniio.GetValue("sql", "databasename") + "server for login " + iniio.GetValue("sql", "databasename") + "server;" +
                        "grant select,insert,update to " + iniio.GetValue("sql", "databasename") + "server;" +
                        "grant delete on dij_temp to " + iniio.GetValue("sql", "databasename") + "server;" +
                        "grant delete on dij_ans to " + iniio.GetValue("sql", "databasename") + "server;" +
                        "grant delete on order_cache to " + iniio.GetValue("sql", "databasename") + "server;" +
                        "grant execute on dij to " + iniio.GetValue("sql", "databasename") + "server";
                    mcmd = new SqlCommand(createuser, conadmin);
                    mcmd.ExecuteNonQuery();
                }
                catch(Exception ex)
                { }

                connsql = "Data Source=.;uid=\'" + iniio.GetValue("sql", "databasename") + "server\';pwd=\'trafficserver\';database=" + iniio.GetValue("sql", "databasename") + ";";
                conn = new SqlConnection();
                conn.ConnectionString = connsql;
                conn.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("连接数据库失败,稍后再试或联系管理员\n错误信息：" + ex.Message, "出现错误");
                this.Close();
            }
            try
            {
                String sql1 = "select distinct traffic_start_point from(select*from traffic_bus union all select*from traffic_plane union all select*from traffic_train union all select*from traffic_hstrain)t"; // 查询语句
                String sql2 = "select distinct traffic_end_point from(select*from traffic_bus union all select*from traffic_plane union all select*from traffic_train union all select*from traffic_hstrain)t";
                SqlDataAdapter myda = new SqlDataAdapter(sql1, conn);
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                for(int i=0;i<dt.Rows.Count;++i)
                    cb_start.Items.Add(dt.Rows[i]["traffic_start_point"].ToString());
                myda = new SqlDataAdapter(sql2, conn);
                dt = new DataTable();
                myda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; ++i)
                    cb_end.Items.Add(dt.Rows[i]["traffic_end_point"].ToString());
                cb_start.SelectedIndex = 0;
                cb_end.SelectedIndex = 0;
                cb_best.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接数据库失败,稍后再试或联系管理员\n错误信息：" + ex.Message, "出现错误");
                this.Close();
            }
        }


        private void Linklogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//link_login
        {
            if ((doing&1) != 0)
                return;
            doing = doing | 1;
            Form_login login = new Form_login(this);
            login.Show();
        }

        private void Button1_Click(object sender, EventArgs e) //button_query
        {
            if((userpower&1)==0)
            {
                MessageBox.Show("账号被封禁!", "Error");
                error_info = "封禁账户尝试查询路线";
                return;
            }
            Dij(cb_start.SelectedItem.ToString(), cb_end.SelectedItem.ToString(),Tp_time.Value.ToString(),cb_best.SelectedIndex);
        }

        private void Button2_Click(object sender, EventArgs e) //button_order
        {
            if ((doing&2) != 0)
                return;
			if((userpower&1)==0)
			{
				MessageBox.Show("账号被封禁!", "Error");
                error_info = "封禁账户尝试创建订单";
				return;
			}
            if (Id.Equals(""))
            {
                MessageBox.Show("登录之后才能进行该操作");
                error_info = "创建订单前未登录";
                return;
            }
            if((userpower&2)!=2)
            {
                if((userpower&4)==4)
                {
                    MessageBox.Show("管理者不可参与订票,若需要订票请更换个人普通账户");
                    error_info = "管理者尝试订票";
                    return;
                }
                MessageBox.Show("实名制后才能进行该操作");
                error_info = "创建订单前为实名制";
                return;
            }
            doing =doing | 2;
            Form_order_submit order = new Form_order_submit(this,dt_son);
            order.Show();
        }

        private void Button_realname_Click(object sender, EventArgs e) //实名
        {
			try
			{
				string sql = "update user_info set user_power=user_power+2 where user_id=\'" + Id + "\'";
				SqlCommand myda = new SqlCommand(sql, conn);
				int a = myda.ExecuteNonQuery();
				MessageBox.Show("实名制完成,请重新登录");
				nickname = "游客";
				Id = "";
				userpower = 1;
				money = 0;
				Newuser();
			}
			catch(Exception ex)
			{
				MessageBox.Show("错误信息：" + ex.Message, "出现错误");
			}
        }

		private void LL_money_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            if ((userpower&1) == 0)
            {
                MessageBox.Show("账号被封禁!", "Error");
                error_info = "封禁账户尝试充值";
                return;
            }
            if(Id=="")
            {
                MessageBox.Show("登录之后才能进行该操作");
                error_info = "创建订单前未登录";
                return;
            }
            Bt_pay.Visible = true;
            Pb_pay.Visible = true;
            Pb_pay.BringToFront();
            Bt_pay.BringToFront();

        }

		private void Label_name_Click(object sender, EventArgs e)
		{
            if ((doing & 32) != 0 || Id=="")
                return;
            doing = doing | 32;
            Form_user updateinfo = new Form_user(this);
            updateinfo.Show();
		}

		private void Label_name_MouseEnter(object sender, EventArgs e)
		{
            if (Id == "")
                return;
            Lb_name.Font = new Font("宋体", 9, FontStyle.Underline);
            tip.Show("查看订票记录", Lb_name); 
        }

		private void Label_name_MouseLeave(object sender, EventArgs e)
		{
            if (Id == "")
                return;
            Lb_name.Font = new Font("宋体", 9);
            tip.Hide(Lb_name);
		}

        private void Bt_admin_Click(object sender, EventArgs e)
        {
			if ((doing & 4) != 0)
				return;
			doing = doing | 4;
			Form_command command = new Form_command();
			command.Show();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			ServiceController sc = new ServiceController(dbservername);
			if (doing!=0)
			{
				MessageBox.Show("有其他窗口未关闭,无法退出程序!");
				e.Cancel = true;
			}
			else if(sc.Status!=ServiceControllerStatus.Stopped)
			{
                try
                {
                    if (conn.State != ConnectionState.Closed)
                        conn.Close();
                    if (conadmin.State != ConnectionState.Closed)
                        conadmin.Close();  
                }
                catch(Exception ex)
                {
                    MessageBox.Show("错误信息：" + ex.Message, "出现错误");
                }
                try
                {
                    DialogResult re = MessageBox.Show("是否要关闭SQL服务？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (re == DialogResult.Yes)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("错误信息：" + ex.Message, "出现错误");
                }
            }
		}

        private void Bt_order_clicked(object sender, EventArgs e)
        {
            if ((doing & 16) != 0)
                return;
            Form_order_query userinfo = new Form_order_query(this);
            doing = doing | 16;
            userinfo.Show();
        }

        private void Bt_pay_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update user_info set user_money=user_money+200 where user_id=\'" + Id + "\';" +
                    "select * from user_info where user_id=\'" + Id + "\'";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                Bt_pay.Visible = false;
                Pb_pay.Visible = false;
                MessageBox.Show("充值完成");
                money = Convert.ToDouble(dt.Rows[0]["user_money"]);
                Newuser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }
    }
}
