using SchoolMealFinder.DBConn;
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
			DateTb.Text = DateTime.Now.ToShortDateString();
			GetMenu(1);
            GetMenu(2);
            GetMenu(3);
        }

        private void GetMenu(int mealType)
        {
            var myRead = MysqlConn.ExecuteQuery("select * from meal natural join food where meal_date = '" + DateTime.Now.ToShortDateString() + "' and meal_type=" + mealType +";");
            string menuString = "";
            while (myRead.Read())
            {
                menuString += myRead["food_info"] + "\n";
            }

            if(menuString == "")
            {
                return;
            }

            switch (mealType)
            {
                case 1:
                    type1Tb.Text = menuString;
                    break;
                case 2:
                    type2Tb.Text = menuString;
                    break;
                case 3:
                    type3Tb.Text = menuString;
                    break;
            }
            return;
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
            if (temp != "정보 없음.")
            {
                MessageBox.Show("급식이 이미 등록되었습니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EnrollCtrl.SetMealType(Int32.Parse(button.Tag.ToString()));
            EnrollCtrl.Visibility = Visibility.Visible;
        }

        private void EnrollCtrl_UpdateMeal(int mealType)
        {
            GetMenu(mealType);
        }
    }
}