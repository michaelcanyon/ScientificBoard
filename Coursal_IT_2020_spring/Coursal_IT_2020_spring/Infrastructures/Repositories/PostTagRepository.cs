using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
            SqlParameter PostId = new SqlParameter("@postId",  postId);
            var pairs = await Database.PostsTags.FromSqlRaw("SELECT * FROM PostsTags WHERE PostId LIKE @postId", PostId).ToListAsync();
            return pairs;
        }
        public async Task<List<PostTag>> GetPostsIdList(int TagId)
        {
            SqlParameter tagId = new SqlParameter("@tagId", TagId);
            var pairs = await Database.PostsTags.FromSqlRaw("SELECT * FROM PostsTags WHERE TagId LIKE @tagId", tagId).ToListAsync();
            return pairs;
        }

        public async Task Update(PostTag entity)
        {
            SqlParameter postid = new SqlParameter("@postId", entity.PostId);
            SqlParameter tagId = new SqlParameter("@tagId", entity.TagId);
            SqlParameter id = new SqlParameter("@id", entity.Id);
            await Database.Database.ExecuteSqlRawAsync("UPDATE PostTags SET PostId=@postId, TagId=tagId WHERE Id LIKE @id ", postid, id, tagId);
        }

        public async Task<PostTag> GetSingle(int id)
        {
            SqlParameter Id = new SqlParameter("@id", id);
            var tags = await Database.PostsTags.FromSqlRaw("SELECT * FROM Tags WHERE Id LIKE @id", Id).ToListAsync();
            foreach (var i in tags)
            {
                return i;
            }
            return null;
        }

        public async Task<List<PostTag>> GetList()
        {
            return await Database.PostsTags.ToListAsync();
        }
    }
}
