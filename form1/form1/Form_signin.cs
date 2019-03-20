using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace form1
{
	public partial class Form_signin : bianliang
	{
		Form_login fa=new Form_login();
		private bool Coulddo_id(string a)
		{
			if (a.Equals(""))
			{
				return false;
			}
				
			return true;
		}
		private bool Coulddo_phone(string a)
		{
			if (a.Equals(""))
			{
				return false;
			}

			return true;
		}
		private bool Coulddo_nn(string a)
		{
			if (a.Equals(""))
				return false;
			return true;
		}
		private bool Coulddo_p(string a)
		{
			if (a.Equals(""))
				return false;
			return true;
		}
		public Form_signin()
		{
			InitializeComponent();
		}
		public Form_signin(Form_login ls)
		{
			InitializeComponent();
			fa = ls;
		}
		private void Form_signin_FormClosed(object sender, FormClosedEventArgs e)
		{
			doing = doing & ~8;
		}

		private void Tb_id_Leave(object sender, EventArgs e)
		{
			try
			{
				String sql = "select * from user_info where user_id=@uid;";
				SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
				myda.SelectCommand.Parameters.Add(new SqlParameter("@uid", Tb_id.Text));
				DataTable dt = new DataTable(); // 实例化数据表
				myda.Fill(dt); // 保存数据
				if (dt.Rows.Count != 0)
				{
					error_info = "id已存在";
					Lb_id.Visible = true;
					return;
				}
				if (!Coulddo_id(Tb_id.Text))
				{
					error_info = "id非法";
					Lb_id.Visible = true;
					return;
				}
				Lb_id.Visible = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show("错误信息：" + ex.Message, "出现错误");
			}
		}

		private void Tb_nn_Leave(object sender, EventArgs e)
		{

			if (!Coulddo_nn(Tb_nn.Text))
			{
				error_info = "昵称非法";
				Lb_nn.Visible = true;
			}
			else
			{
				Lb_nn.Visible = false;
			}
		}

		private void Tb_p_Leave(object sender, EventArgs e)
		{
			if (!Coulddo_p(Tb_p.Text))
			{
				error_info = "密码非法";
				Lb_p.Visible = true;
			}
			else
			{
				Lb_p.Visible = false;
			}
			Tb_cp_Leave(new object(), new EventArgs());
		}

		private void Tb_cp_Leave(object sender, EventArgs e)
		{
			if (!Tb_p.Text.Equals(Tb_cp.Text))
			{
				error_info = "密码不一致";
				Lb_cp.Visible = true;
			}
			else
			{
				Lb_cp.Visible = false;
			}
		}
		private void Tb_phone_Leave(object sender, EventArgs e)
		{
			if (!Coulddo_phone(Tb_phone.Text))
			{
				error_info = "手机号不合法";
				Lb_phone.Visible = true;
			}
			else
			{
				Lb_phone.Visible = false;
			}
		}
		private void Button1_Click(object sender, EventArgs e)
		{
			if (!code_cmp(Tb_ver.Text))
			{
				MessageBox.Show("验证码错误");
				return;
			}
			Tb_nn_Leave(new object(),new EventArgs());
			Tb_id_Leave(new object(), new EventArgs());
			Tb_p_Leave(new object(), new EventArgs());
			Tb_cp_Leave(new object(), new EventArgs());
			Tb_phone_Leave(new object(), new EventArgs());
			if (Lb_cp.Visible ||Lb_id.Visible ||Lb_nn.Visible ||Lb_p.Visible||Lb_phone.Visible)
			{
				MessageBox.Show("有信息不合法,请检查");
				return;
			}
			try
			{
				String sql = "insert into user_info(user_id,user_nick,user_pswd,user_money,user_power,user_phone,user_textnum) values(@uid,@unn,@upswd,0,1,@upn,0)";
				SqlCommand myda = new SqlCommand(sql, conn);
				myda.Parameters.Add(new SqlParameter("@uid", Tb_id.Text));
				myda.Parameters.Add(new SqlParameter("@unn", Tb_nn.Text));
				myda.Parameters.Add(new SqlParameter("@upswd", Tb_p.Text));
				myda.Parameters.Add(new SqlParameter("@upn", Tb_phone.Text));
				int a = myda.ExecuteNonQuery();
				if (a == 2)
				{
					MessageBox.Show("注册成功");
					fa.Setvaules(Tb_id.Text, Tb_p.Text);
					this.Close();
				}
				else
					MessageBox.Show("注册失败,请联系管理员");
			}
			catch (Exception ex)
			{
				MessageBox.Show("错误信息：" + ex.Message, "出现错误");
			}

		}
	}
}
