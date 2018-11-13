using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMealFinder.Model
{
    class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string id;
        public string Id
        {
            get => id;
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private int auth = 0; // 0 : 학생. 1 : 관리자
        public int Auth
        {
            get => auth;
            set
            {
                auth = value;
                NotifyPropertyChanged("Auth");
            }
        }

        private int schoolIdx;
        public int SchoolIdx
        {
            get => schoolIdx;
            set
            {
                schoolIdx = value;
                NotifyPropertyChanged("SchoolIdx");

            }
        }

    }
}
