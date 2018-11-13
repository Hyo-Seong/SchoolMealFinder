﻿using SchoolMealFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMealFinder.ViewModel
{
    class MealViewModel
    {
        public ObservableCollection<Meal> Items { get; } = new ObservableCollection<Meal>();

    }
}