using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coursal_IT_2020_spring.Models
{
    public class Blog:Entity
    {
        public List<Post> Posts { get; set; } 
        public User Author { get; set; }

    }
}
