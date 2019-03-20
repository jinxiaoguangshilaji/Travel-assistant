using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Security.Cryptography;

namespace form1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
	public class iniio:Form
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


		public static void SetValue(string section, string key, string value)
		{
			try
			{
				WritePrivateProfileString(section, key, value, inifilepath);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
    public class bianliang : iniio
    {
        public static int doing = 0; //32
        public static String nickname = "游客";
        private static String id = "";
        public static double money = 0;
        public static int userpower = 1;
        public static String connsql;
        public static SqlConnection conn;
        public static string conadminsql;
        public static SqlConnection conadmin;
        public static string error_info="";
        public static string dbservername = "";
		public static string selected = " t.traffic_id as \'车次号\',t.traffic_start_point as \'起点\',t.traffic_start_time as \'出发时间\',t.traffic_end_point as \'终点\',t.traffic_end_time as \'到站时间\',t.traffic_cost as \'票价\'";
		public static string selected2 = "";
		public static string Getmd5(string pswd)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(pswd)), 4, 8);
			t2 = t2.Replace("-", "");
			t2 = t2.ToLower();
			return t2;
		}
		public static string Id { get => id; set => id = value; }

        public bool code_cmp(string a) { return a.Equals("2333"); }

	}

}
