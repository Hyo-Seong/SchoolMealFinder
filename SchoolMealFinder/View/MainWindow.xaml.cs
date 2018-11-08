using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace SchoolMealFinder.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string Sha512Hash(string str)
        {
            var sha512 = new SHA512CryptoServiceProvider();
            byte[] resultHash = sha512.ComputeHash(Encoding.Default.GetBytes(str));
            string transPwd = string.Empty;

            foreach (byte x in resultHash)
            {
                transPwd += $"{x:x2}";
            }

            return transPwd;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(idTb.Text == "" || pwPb.Password == "")
            {
                MessageBox.Show("아이디 또는 비밀번호를 입력하세요.", "Error!");
            }


        }
    }
}
