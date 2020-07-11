using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.EF;
using Microsoft.EntityFrameworkCore;

namespace Coursal_IT_2020_spring.Infrastructures.Repositories
{
    public class PostTagRepository : IPostTagRepository
    {
        protected BoardContext Database { get; set; }
        public PostTagRepository(BoardContext database)
        {
            Database = database;
        }
        public async Task Create(PostTag postTagPair)
        {
            Database.PostsTags.Add(postTagPair);
            await Database.SaveChangesAsync();
        }

        public async Task Delete(PostTag postTagPair)
        {
            Database.PostsTags.Remove(postTagPair);
            await Database.SaveChangesAsync();
        }

        public async Task<List<PostTag>> GetTagsIdList(int postId)
        {
            System.Data.SqlClient.SqlParameter PostId = new System.Data.SqlClient.SqlParameter("@postId",  postId);
            var pairs = await Database.PostsTags.FromSqlRaw("SELECT * FROM PostsTags WHERE PostId LIKE @postId", PostId).ToListAsync();
            return pairs;
        }
        public async Task<List<PostTag>> GetPostsIdList(int TagId)
        {
            System.Data.SqlClient.SqlParameter tagId = new System.Data.SqlClient.SqlParameter("@tagId", TagId);
            var pairs = await Database.PostsTags.FromSqlRaw("SELECT * FROM PostsTags WHERE TagId LIKE @tagId", tagId).ToListAsync();
            return pairs;
        }

        public Task Update(PostTag entity)
        {
            throw new NotImplementedException();
        }

        public Task<PostTag> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostTag>> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
