using SchoolMealFinder.DBConn;
using SchoolMealFinder.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Interaction logic for ShowMealControl.xaml
    /// </summary>
    public partial class ShowMealControl : UserControl
    {
        public ShowMealControl()
        {
            InitializeComponent();
        }

        public void SetTodayMeal()
        {
            Debug.WriteLine(DateTime.Now.ToShortDateString());
            var myRead = MysqlConn.ExecuteQuery("select * from meal natural join food where meal_date = '" + DateTime.Now.ToShortDateString() + "' and meal_type=1;");
            string menuString1 = "";
            while (myRead.Read())
            {
                menuString1 += myRead["food_info"] + "\n";
            }

            if(menuString1 != "")
            {
                type1Tb.Text = menuString1;
            }

            myRead = MysqlConn.ExecuteQuery("select * from meal natural join food where meal_date = '" + DateTime.Now.ToShortDateString() + "' and meal_type=2;");
            string menuString2 = "";
            while (myRead.Read())
            {
                menuString2 += myRead["food_info"] + "\n";
            }

            if (menuString2 != "")
            {
                type2Tb.Text = menuString2;
            }

            myRead = MysqlConn.ExecuteQuery("select * from meal natural join food where meal_date = '" + DateTime.Now.ToShortDateString() + "' and meal_type=3;");
            string menuString3 = "";
            while (myRead.Read())
            {
                menuString3 += myRead["food_info"] + "\n";
            }

            if (menuString3 != "")
            {
                type3Tb.Text = menuString3;
            }
        }

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string temp = "";
            switch (button.Tag)
            {
                case "1":
                    temp = type1Tb.Text;
                    break;
                case "2":
                    temp = type2Tb.Text;
                    break;
                case "3":
                    temp = type3Tb.Text;
                    break;
            }
            if (temp != "정보없음")
            {
                MessageBox.Show("급식이 이미 등록되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EnrollCtrl.SetMealType(Int32.Parse(button.Tag.ToString()));
            EnrollCtrl.Visibility = Visibility.Visible;
        }
    }
}