using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServerDbApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
