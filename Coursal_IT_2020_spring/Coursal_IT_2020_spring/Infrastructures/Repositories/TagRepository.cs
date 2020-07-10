using Coursal_IT_2020_spring.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.EF;

namespace Coursal_IT_2020_spring.Infrastructures.Repositories
{
    public class TagRepository : IBaseRepository<Tag>
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

        public Task<Tag> GetSingle(int id)
        {
            return null;
        }

        public Task<List<Tag>> GetList()
        {
            return null;
        }
    }
}
