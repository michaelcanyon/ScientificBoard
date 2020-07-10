using Coursal_IT_2020_spring.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Coursal_IT_2020_spring.EF
{
    public class BoardDbInitialser:DropCreateDatabaseIfModelChanges<BoardContext>
    {
        protected override void Seed(BoardContext db)
        {
            db.Posts.Add(new Post { AuthorId=1, Publicationtime = DateTime.Now, Text = "123fourfivesix", Title = "countPost" });
            db.SaveChangesAsync();
        }
    }
}
