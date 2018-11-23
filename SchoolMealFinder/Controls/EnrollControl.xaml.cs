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
    /// Interaction logic for EnrollControl.xaml
    /// </summary>
    public partial class EnrollControl : UserControl
    {
        public delegate void UpdateMealHandler(int mealType);
        public event UpdateMealHandler UpdateMeal;

        public EnrollControl()
        {
            InitializeComponent();
        }

        private int mealType;

        public void SetMealType(int mealType)
        {
            this.mealType = mealType;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tempTb.Text = "";
            this.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int mealIdx = 0;
            int a = MysqlConn.ExecuteNonQuery("insert into meal(meal_date, meal_type) values('" + DateTime.Now.ToShortDateString() + "', " + mealType + ");");
            //mealIdx 찾아서 insert
            var myRead = MysqlConn.ExecuteQuery("select meal_idx from meal where meal_date ='" + DateTime.Now.ToShortDateString() + "' and meal_type = " + mealType + ";");
            if (myRead.Read())
            {
                mealIdx = Int32.Parse(myRead["meal_idx"].ToString());
            }

            if(mealIdx == 0)
            {
                //에러
                MessageBox.Show("알수없는 에러.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string[] temp = tempTb.Text.ToString().Split(',');
            for(int i=0; i<temp.Length; i++)
            {
                int b = MysqlConn.ExecuteNonQuery("insert into food(food_info, meal_idx) values('" + temp[i] + "', " + mealIdx + ");");
            }
            MessageBox.Show("급식이 등록되었습니다.", "알림", MessageBoxButton.OK);
			tempTb.Text = "";
			UpdateMeal?.Invoke(mealType);
            this.Visibility = Visibility.Collapsed;
        }
    }
}