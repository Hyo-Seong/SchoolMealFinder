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
            Debug.WriteLine(DateTime.Now.ToShortDateString());
            var myRead = MysqlConn.ExecuteQuery("select * from meal natural join food where meal_date = '" + DateTime.Now.ToShortDateString() + "' and meal_type=1;");
            while (myRead.Read())
            {
                Debug.WriteLine(myRead["meal_date"] + " " + myRead["food_info"]);
            }
        }
    }
}
