using SchoolMealFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMealFinder.ViewModel
{
    public class MealViewModel
    {
        public ObservableCollection<Meal> Items { get; set; } = new ObservableCollection<Meal>();
    }
}
