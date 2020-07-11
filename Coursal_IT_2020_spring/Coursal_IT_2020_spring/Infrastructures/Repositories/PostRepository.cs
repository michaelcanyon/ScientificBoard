using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.EF;
using System.Data.Entity;

namespace Coursal_IT_2020_spring.Infrastructures
{
    /// <summary>
    /// Действия с объектом поста
    /// </summary>
    public class PostRepository : IPostRepository
    {
        protected BoardContext Database { get; set; }
        public PostRepository(BoardContext database)
        {
            Database = database;
        }

        public async Task Create(Post post)
        {
            Database.Posts.Add(post);
            await Database.SaveChangesAsync();
        }

        public async Task Delete(Post entity)
        {
            Database.Posts.Remove(entity);
            await Database.SaveChangesAsync();
        }

        public async Task<List<Post>> GetList()
        {
            return await Database.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByTitle(string Title, string authorNickname)
        {
            System.Data.SqlClient.SqlParameter nickname = new System.Data.SqlClient.SqlParameter("@authorNickname", "%" + authorNickname + "%");
            System.Data.SqlClient.SqlParameter title = new System.Data.SqlClient.SqlParameter("@title", "%" + Title + "%");
            var posts = await Database.Database.SqlQuery<Post>("SELECT * FROM Posts WHERE Title LIKE @title " +
                "AND AuthorId LIKE ( SELECT TOP 1 Id FROM Users WHERE nickname LIKE @authorNickname ) ", nickname, title).ToListAsync();
            foreach (var i in posts)
            {
                return i;
            }
            return null;
        }
        public async Task<List<Post>> GetPostsByAuthor(int authorId)
        {
            System.Data.SqlClient.SqlParameter AuthorId = new System.Data.SqlClient.SqlParameter("@AuthorId", authorId);
            var posts = await Database.Database.SqlQuery<Post>("SELECT * FROM Posts WHERE Id LIKE @AuthorId ", AuthorId).ToListAsync();
            return posts;
        }
        //public async Task<List<Post>> GetPostsByCategory(string category)
        //{
        //    System.Data.SqlClient.SqlParameter Category = new System.Data.SqlClient.SqlParameter("@Category", category);
        //    var posts = await Database.Database.SqlQuery<Post>("SELECT * FROM PostsTags WHERE TagId LIKE @Category ", Category).ToListAsync();
        //    return posts;
        //}

        public async Task<Post> GetSingle(int PostId)
        {
            System.Data.SqlClient.SqlParameter postId = new System.Data.SqlClient.SqlParameter("@postId", PostId);
            var posts = await Database.Database.SqlQuery<Post>("SELECT * FROM Posts WHERE Id LIKE @postId ", postId).ToListAsync();
            foreach (var i in posts)
            {
                return i;
            }
            return null;
        }

        public async Task Update(Post entity)
        {
            System.Data.SqlClient.SqlParameter title = new System.Data.SqlClient.SqlParameter("@title", entity.Title);
            System.Data.SqlClient.SqlParameter text = new System.Data.SqlClient.SqlParameter("@text", entity.Text);
            System.Data.SqlClient.SqlParameter time = new System.Data.SqlClient.SqlParameter("@time", entity.Publicationtime);
            System.Data.SqlClient.SqlParameter author = new System.Data.SqlClient.SqlParameter("@author", entity.AuthorId);
            System.Data.SqlClient.SqlParameter id = new System.Data.SqlClient.SqlParameter("@id", entity.Id);
            await Database.Database.SqlQuery<Post>("UPDATE Posts SET Title=@title, Text=@text, Publicationtime=@time, AuthorId=@author " +
                "WHERE Id LIKE @id "
                , title, text, time, author, id).ToListAsync();
        }
    }

}
