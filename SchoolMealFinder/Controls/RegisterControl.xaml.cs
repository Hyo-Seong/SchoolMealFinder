using SchoolMealFinder.DBConn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolMealFinder.Controls
{
    /// <summary>
    /// Interaction logic for RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(nameTb.Text == "" || idTb.Text == "" || pwPb.Password == "")
            {
                MessageBox.Show("칸을 모두 채워주세요.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var MyRead = MysqlConn.ExecuteQuery("select id from user where id='" + idTb.Text + "'");

            if (MyRead.Read())
            {
                MessageBox.Show("이미 존재하는 아이디입니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var a = MysqlConn.ExecuteNonQuery("insert into user(" + nameTb.Text + ", " + idTb.Text + ", " + pwPb.Password + ")");
            
        }
    }
}
