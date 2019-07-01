using System;
using MySql.Data.MySqlClient;

namespace Demo.Scripts.tools
{
    public static class DBUtility
    {
        private const string CONNECTIONSTRING =
            "data source=39.96.183.75;port=3306;database=strangeiocdemo;user=root;password=imgoul";
        public  static MySqlConnection Connect()
        {
            MySqlConnection conn=new MySqlConnection(CONNECTIONSTRING);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine("连接数据库时出现异常："+e);
                return null;
            }
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            try
            {
                if(conn!=null)
                    conn.Close();
                else
                {
                    Console.WriteLine("MySqlConnection不能为空");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
