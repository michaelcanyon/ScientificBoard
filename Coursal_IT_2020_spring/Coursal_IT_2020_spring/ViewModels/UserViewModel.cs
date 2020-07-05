using Coursal_IT_2020_spring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursal_IT_2020_spring.ViewModels
{
    public class UserViewModel
    {
        public string nickname { get; set; }
        public string blogTitle { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public User ToUserObject()
        {
            return new User { BlogTitle = blogTitle, Email = email, Nickname = nickname, Password = password };
        }
    }
}
