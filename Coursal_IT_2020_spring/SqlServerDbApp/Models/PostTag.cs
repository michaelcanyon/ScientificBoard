using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServerDbApp.Models
{
    public class PostTag:Entity
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }
}
