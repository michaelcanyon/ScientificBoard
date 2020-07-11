using Coursal_IT_2020_spring.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.EF;
using Coursal_IT_2020_spring.Infrastructures.Repositories.Interfaces;

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

        public Task Update(Tag entity)
        {
            return null;
        }

        public async Task<Tag> GetSingle(string tag)
        {
            System.Data.SqlClient.SqlParameter tagName = new System.Data.SqlClient.SqlParameter("@tag", tag);
            var tags = await Database.Database.SqlQuery<Tag>("SELECT * FROM Tags WHERE Title LIKE @tag", tagName).ToListAsync();
            foreach (var i in tags)
            {
                return i;
            }
            return null;
        }

        public async Task<Tag> GetSingle(int tag)
        {
            System.Data.SqlClient.SqlParameter Tag = new System.Data.SqlClient.SqlParameter("@tag", tag);
            var tags = await Database.Database.SqlQuery<Tag>("SELECT * FROM Tags WHERE Id LIKE @tag", Tag).ToListAsync();
            foreach (var i in tags)
            {
                return i;
            }
            return null;
        }

        public Task<List<Tag>> GetList()
        {
            return null;
        }
    }
}
