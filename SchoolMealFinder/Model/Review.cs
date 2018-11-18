using System;
using System.ComponentModel;

namespace SchoolMealFinder.Model
{
    public class Review : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int score;

        public int Score
        {
            get => score;
            set
            {
                score = value;
                NotifyPropertyChanged("Score");
            }
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

        private DateTime createDate;

        public DateTime CreateDate
        {
            get => createDate;
            set
            {
                createDate = value;
                NotifyPropertyChanged("CreateDate");
            }
        }
    }
}