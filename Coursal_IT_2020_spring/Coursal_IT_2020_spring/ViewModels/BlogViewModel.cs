using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;

namespace Coursal_IT_2020_spring.ViewModels
{
    public class BlogViewModel
    {
        public User author { get; set; }
        public List<Post> posts { get; set; }
        public Blog ToBlogObject()
        {
            return new Blog { Author = author, Posts = posts };
        }

    }
}
