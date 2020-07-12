using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SqlServerDbApp.Models
{
    public class Blog:Entity
    {
        public List<Post> Posts { get; set; } 
        public User Author { get; set; }

    }
}
