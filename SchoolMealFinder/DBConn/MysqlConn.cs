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
        public static MySqlCommand SendQuery(string query)
        {
            string sqlStr = ConfigurationManager.AppSettings["DBConn"];

            var Conn = new MySqlConnection(sqlStr);
            Conn.Open();

            return new MySqlCommand(query, Conn);
        }
}
}
