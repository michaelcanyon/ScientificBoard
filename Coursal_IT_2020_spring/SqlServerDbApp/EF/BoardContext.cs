using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlServerDbApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Coursal_IT_2020_spring.EF
{
    public class BoardContext: DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostsTags { get; set; }
        public BoardContext()
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
