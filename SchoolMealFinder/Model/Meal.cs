using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMealFinder.Model
{
    class Meal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int idx;
        public int Idx
        {
            get => idx;
            set
            {
                idx = value;
                NotifyPropertyChanged("Idx");
            }
        }

        private List<string> menuInfos = new List<string>();
        public List<string> MenuInfos
        {
            get => menuInfos;
            set
            {
                menuInfos = value;
                NotifyPropertyChanged("MenuInfos");
            }
        }

        private List<Review> reviews = new List<Review>();
        public List<Review> Reviews
        {
            get => reviews;
            set
            {
                reviews = value;
                NotifyPropertyChanged("Reviews");
            }
        }

        private int mealType;
        public int MealType
        {
            get => mealType;
            set
            {
                mealType = value;
                NotifyPropertyChanged("MealType");
            }
        }
    }
}
