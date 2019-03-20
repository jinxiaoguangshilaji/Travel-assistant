using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace form1
{
    public partial class Form_login : bianliang
    {
        Form1 fa;
        public Form_login()
        {
            InitializeComponent();
        }
        public Form_login(Form1 frm)
        {
            InitializeComponent();
            fa = frm;
        }

        public int Login(String userid, String userpswd)
        {
            userpower = 1;
            nickname = "游客";
            Id = "";
            money = 0;
            try
            {

				String sql = "select*from user_info where user_id=@userid";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
				myda.SelectCommand.Parameters.Add(new SqlParameter("@userid",userid));
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("ID不存在或者数据库错误");
                    error_info = userid + " 查询到 " + dt.Rows.Count.ToString() + "条";
                    return 1;
                }
                if (!(dt.Rows[0]["user_pswd"].ToString().Equals(Getmd5(userpswd))))
                {
                    MessageBox.Show("密码错误");
                    error_info = "密码错误";
                    return 2;
                }
                nickname = dt.Rows[0]["user_nick"].ToString();
                Id = dt.Rows[0]["user_id"].ToString().TrimEnd();
                money = Convert.ToDouble(dt.Rows[0]["user_money"]);
                MessageBox.Show("登录成功");
                userpower = Convert.ToInt32(dt.Rows[0]["user_power"]);
                this.Close();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
                return -1;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (code_cmp(text_code.Text))
                Login(text_uid.Text, text_pswd.Text);
        }
		private void Form_login_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			doing =doing & ~1;
			fa.Newuser();
		}

		private void Button_signin_Click(object sender, EventArgs e)
		{
			if ((doing & 8) != 0)
				return;
			Form_signin signin = new Form_signin(this);
			doing = doing | 8;
			signin.Show();
		}
		public void Setvaules(string u,string p)
		{
			text_uid.Text = u;
			text_pswd.Text = p;
			return;
		}
	}
}
