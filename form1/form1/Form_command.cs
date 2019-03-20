using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace form1
{
public partial class Form_command : bianliang
{
    public Form_command()
    {
        InitializeComponent();
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            String sql = textBox1.Text;
            SqlDataAdapter myda = new SqlDataAdapter(sql, conadmin);
            DataTable dt = new DataTable(); // 实例化数据表
            myda.Fill(dt); // 保存数据
            dataGridView1.DataSource = dt;
        }
        catch (Exception ex)
        {
            MessageBox.Show("错误信息：" + ex.Message, "出现错误");
        }

    }
	private void Form_command_FormClosed(object sender, FormClosedEventArgs e)
	{
		doing = doing & ~4;
	}
	}

}

