using Coursal_IT_2020_spring.EF;
using SqlServerDbApp.Models;
using System;
using System.Linq;

namespace SqlServerDbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BoardContext db = new BoardContext())
            {
                User newuser = new User { BlogTitle = "anyBlog", Nickname = "CharlesXavier", Password = "MindGames", Email = "xav@fdjna.com" };
                User newuser1 = new User { BlogTitle = "newblog", Nickname = "Trinity", Password = "Matroid", Email = "cksmwern@weknj.com" };
                db.Users.Add(newuser);
                db.Users.Add(newuser1);
                db.SaveChanges();
                var users=db.Users.ToList();
                foreach (var i in users)
                {
                    Console.WriteLine($"{i.Id}-{i.Nickname}-{i.Email}-{i.BlogTitle}-{i.Password}");
                    Console.WriteLine('\n');
                }
            }
        }
    }
}
