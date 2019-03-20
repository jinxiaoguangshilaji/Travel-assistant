using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace form1
{
    public partial class Form_user : bianliang
    {
        Form1 fa;
        public Form_user()
        {
            InitializeComponent();
        }
        public Form_user(Form1 ex)
        {
            InitializeComponent();
            fa = ex;
        }
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
        private void Form_user_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select *from user_info where user_id=\'"+Id+"\'";
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                Tb_id.Text = dt.Rows[0]["user_id"].ToString();
                Tb_nn.Text = dt.Rows[0]["user_nick"].ToString();
                Tb_phone.Text = dt.Rows[0]["user_phone"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }

        private void Form_user_FormClosed(object sender, FormClosedEventArgs e)
        {
            doing = doing & ~32;
        }

        private void Tb_p_Leave(object sender, EventArgs e)
        {
            if(!Tb_p.Text.Equals(""))
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
            }
            Tb_cp_Leave(new object(), new EventArgs());
        }

        private void Tb_op_Leave(object sender, EventArgs e)
        {
            if (Tb_op.Text.Equals(""))
            {
                error_info = "修改信息时op为空";
                Lb_op.Visible = true;
            }
            else
            {
                Lb_op.Visible = false;
            }
        }

        private void Tb_nn_Leave(object sender, EventArgs e)
        {
            if (!Coulddo_nn(Tb_nn.Text))
            {
                error_info = "修改信息时昵称非法";
                Lb_nn.Visible = true;
            }
            else
            {
                Lb_nn.Visible = false;
            }
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

        private void Bt_submit_Click(object sender, EventArgs e)
        {
            if (!code_cmp(Tb_ver.Text))
            {
                MessageBox.Show("验证码错误");
                return;
            }
            Tb_nn_Leave(new object(), new EventArgs());
			Tb_op_Leave(new object(), new EventArgs());
			Tb_p_Leave(new object(), new EventArgs());
            Tb_cp_Leave(new object(), new EventArgs());
            Tb_phone_Leave(new object(), new EventArgs());
            if (Lb_cp.Visible || Lb_id.Visible || Lb_nn.Visible || Lb_p.Visible || Lb_phone.Visible || Lb_op.Visible)
            {
                MessageBox.Show("有信息不合法,请检查");
                return;
            }
            try
            {
                String sql1 = "select user_pswd from user_info where user_id=@uid";
                SqlDataAdapter myda = new SqlDataAdapter(sql1, conn);
				myda.SelectCommand.Parameters.Add(new SqlParameter("@uid", Tb_id.Text));
                DataTable dt = new DataTable(); // 实例化数据表
                myda.Fill(dt); // 保存数据
                if (!dt.Rows[0][0].ToString().Equals(Getmd5(Tb_op.Text)))
                {
                    MessageBox.Show("当前密码错误!");
                    return;
                }
                string sql = "update user_info set user_nick=@nickname,user_phone=@phone";
                if (!Tb_p.Text.Equals(""))
					sql += ",user_pswd=@pswd";         
                sql += " where user_id=@id";
                SqlCommand mycmd = new SqlCommand(sql, conn);
				mycmd.Parameters.Add(new SqlParameter("@nickname", Tb_nn.Text));
				mycmd.Parameters.Add(new SqlParameter("@phone", Tb_phone.Text));
				if (!Tb_p.Text.Equals(""))
					mycmd.Parameters.Add(new SqlParameter("@pswd",Tb_p.Text));
				mycmd.Parameters.Add(new SqlParameter("@id", Tb_id.Text));
				int a = mycmd.ExecuteNonQuery();
                if (a == 2)
                {
                    if(!Tb_p.Text.Equals(""))
                    {
                        MessageBox.Show("修改成功,请重新登录");
                        Id = "";
                        money = 0;
                        nickname = "游客";
                    }
                    else
                    {
                        MessageBox.Show("修改成功");
                        nickname = Tb_nn.Text;
                    }
                    fa.Newuser();
                    this.Close();
                } 
                else
                    MessageBox.Show("修改失败,请联系管理员");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误信息：" + ex.Message, "出现错误");
            }
        }
    }
}
