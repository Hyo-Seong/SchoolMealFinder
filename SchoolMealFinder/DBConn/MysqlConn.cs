using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolMealFinder.DBConn
{
    public class MysqlConn
    {
        public static MySqlDataReader ExecuteQuery(string query)
        {
            string sqlStr = ConfigurationManager.AppSettings["DBConn"];
            var Conn = new MySqlConnection(sqlStr);
            Conn.Open();
            var Comm = new MySqlCommand(query, Conn);
            return Comm.ExecuteReader();
        }

        public static int ExecuteNonQuery(string query)
        {
            try
            {
                string sqlStr = ConfigurationManager.AppSettings["DBConn"];
                MySqlConnection Conn = new MySqlConnection(sqlStr);
                Conn.Open();
                var Comm = new MySqlCommand(query, Conn);
                return Comm.ExecuteNonQuery();
            } catch
            {
                return -1;
            }
        }
    }
}
