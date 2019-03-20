using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        private static string inifilename = "traffic_conf.ini";
        private static string inifilepath = AppDomain.CurrentDomain.BaseDirectory + inifilename;

        public static string GetValue(string section, string key)
        {
            StringBuilder s = new StringBuilder(1024);
            GetPrivateProfileString(section, key, "", s, 1024, inifilepath);
            return s.ToString();
        }





        
        public Form1()
        {
            InitializeComponent();
        }

        private void Bt_bk_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            string text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory +"back.sql", System.Text.Encoding.GetEncoding("gb2312"));
            text = text.Replace("@DATANAME", GetValue("sql", "databasename"));
            text = text.Replace("@FILEPATH", AppDomain.CurrentDomain.BaseDirectory);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "backreal.sql", text, Encoding.GetEncoding("gb2312"));
            p.StandardInput.WriteLine("osql.exe -E -i backreal.sql" + "&exit");
            p.StandardInput.AutoFlush = true;
            p.WaitForExit();//等待程序执行完退出进程
            string output = p.StandardOutput.ReadToEnd();
            MessageBox.Show(output);
            Checkit();
            p.Close();
        }
        public void Checkit()
        {
            string fileexist = AppDomain.CurrentDomain.BaseDirectory + GetValue("sql", "databasename") + ".BAK";
            if (System.IO.File.Exists(fileexist))
                Bt_st.Enabled = true;
            else
                Bt_st.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string dbservername = "";
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
                                s.Stop();
                                s.WaitForStatus(ServiceControllerStatus.Stopped);
                                s.Start();
                                s.WaitForStatus(ServiceControllerStatus.Running);
                                MessageBox.Show("SQL服务重启成功");
                            }
                        }
                }
                if (dbservername.Equals(""))
                {
                    MessageBox.Show("未找到名为SQL Server的服务,请检查是否安装了MSSQL");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("sql服务启动失败\n"+ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            Checkit();
        }

        private void Bt_st_Click(object sender, EventArgs e)
        {
            Checkit();
            if (Bt_st.Enabled == false)
                return;
            Bt_delete_Click(new object(), new EventArgs());
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序
            string text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "store.sql", System.Text.Encoding.GetEncoding("gb2312"));
            text = text.Replace("@DATANAME", GetValue("sql", "databasename"));
            text = text.Replace("@FILEPATH", AppDomain.CurrentDomain.BaseDirectory);
            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "storereal.sql", text, Encoding.GetEncoding("gb2312"));
            p.StandardInput.WriteLine("osql.exe -E -i storereal.sql" + "&exit");
            p.StandardInput.AutoFlush = true;
            p.WaitForExit();//等待程序执行完退出进程
            string output = p.StandardOutput.ReadToEnd();
            MessageBox.Show(output);
            p.Close();
        }

        private void Bt_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string conadminsql = "server=.;integrated security=SSPI;Connect Timeout=30";
                SqlConnection conadmin = new SqlConnection();
                conadmin.ConnectionString = conadminsql;
                conadmin.Open();
                string sql = "drop database " + GetValue("sql", "databasename");
                SqlCommand mcmd = new SqlCommand(sql, conadmin);
                int a = mcmd.ExecuteNonQuery();
                if(a<1)
                MessageBox.Show("删除成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show("错误:" + ex.ToString());
            }
        }
    }
}
