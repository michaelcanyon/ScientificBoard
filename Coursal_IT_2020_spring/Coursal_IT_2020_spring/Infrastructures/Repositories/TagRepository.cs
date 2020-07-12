using Coursal_IT_2020_spring.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Coursal_IT_2020_spring.Infrastructures.Repositories
{
    public class TagRepository : ITagRepository
    {
        protected BoardContext Database { get; set; }
        public TagRepository(BoardContext database)
        {
            Database = database;
        }
        public async Task Create(Tag tag)
        {
            Database.Tags.Add(tag);
            await Database.SaveChangesAsync();
        }

        public async Task Delete(Tag tag)
        {
            Database.Tags.Remove(tag);
            await Database.SaveChangesAsync();
        }

        public async Task Update(Tag entity)
        {
            
            SqlParameter nickname = new SqlParameter("@title", entity.Title);
            SqlParameter id = new SqlParameter("@id", entity.Id);
            await Database.Database.ExecuteSqlRawAsync("UPDATE Tags SET Title=@title WHERE Id LIKE @id ", nickname, id);
        }

        public async Task<Tag> GetSingle(string tag)
        {
            SqlParameter tagName = new SqlParameter("@tag", tag);
            var tags = await Database.Tags.FromSqlRaw("SELECT * FROM Tags WHERE Title LIKE @tag", tagName).ToListAsync();
            foreach (var i in tags)
            {
                return i;
            }
            return null;
        }

        public async Task<Tag> GetSingle(int tag)
        {
            SqlParameter Tag = new SqlParameter("@tag", tag);
            var tags = await Database.Tags.FromSqlRaw("SELECT * FROM Tags WHERE Id LIKE @tag", Tag).ToListAsync();
            foreach (var i in tags)
            {
                return i;
            }
            return null;
        }

        public async Task<List<Tag>> GetList()
        {
            return await Database.Tags.ToListAsync();
        }
    }
}
