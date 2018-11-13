using SchoolMealFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMealFinder.ViewModel
{
    class UserViewModel
    {
        public ObservableCollection<User> Items { get; } = new ObservableCollection<User>();

        public string GetNameById(string id)
        {
            foreach(User user in Items)
            {
                if(user.Id == id)
                {
                    return user.Name;
                }
            }
            return null;
        }


    }
}
