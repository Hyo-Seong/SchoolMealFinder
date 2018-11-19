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
        public EnrollControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tempTb.Text = "";
            this.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] temp = tempTb.Text.ToString().Split(',');
            for(int i=0; i<temp.Length; i++)
            {
                Debug.WriteLine(temp[i]);
                //이부분에서 DB Query 날려줘야됨.
            }
            this.Visibility = Visibility.Collapsed;
        }
    }
}
