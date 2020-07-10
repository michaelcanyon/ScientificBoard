using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;
using System.Data.Entity;

namespace Coursal_IT_2020_spring.EF
{
    public class BoardContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostsTags { get; set; }
        static BoardContext()
        {
            Database.SetInitializer<BoardContext>(new BoardDbInitialser());
        }
        public BoardContext(string connectionString) : base(connectionString) { }
    }
}
