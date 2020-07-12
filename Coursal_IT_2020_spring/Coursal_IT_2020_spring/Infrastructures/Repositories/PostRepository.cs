using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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
            SqlParameter nickname = new SqlParameter("@authorNickname", "%" + authorNickname + "%");
            SqlParameter title = new SqlParameter("@title", "%" + Title + "%");
            var posts = await Database.Posts.FromSqlRaw("SELECT * FROM Posts WHERE Title LIKE @title " +
                "AND AuthorId LIKE ( SELECT TOP 1 Id FROM Users WHERE Nickname LIKE @authorNickname ) ", nickname, title).ToListAsync();
            foreach (var i in posts)
            {
                return i;
            }
            return null;
        }
        public async Task<List<Post>> GetPostsByAuthor(int authorId)
        {
            SqlParameter AuthorId = new SqlParameter("@AuthorId", authorId);
            var posts = await Database.Posts.FromSqlRaw("SELECT * FROM Posts WHERE AuthorId LIKE @AuthorId ", AuthorId).ToListAsync();
            return posts;
        }
        //public async Task<List<Post>> GetPostsByCategory(string category)
        //{
        //    SqlParameter Category = new SqlParameter("@Category", category);
        //    var posts = await Database.Database.SqlQuery<Post>("SELECT * FROM PostsTags WHERE TagId LIKE @Category ", Category).ToListAsync();
        //    return posts;
        //}

        public async Task<Post> GetSingle(int PostId)
        {
            SqlParameter postId = new SqlParameter("@postId", PostId);
            var posts = await Database.Posts.FromSqlRaw("SELECT * FROM Posts WHERE Id LIKE @postId ", postId).ToListAsync();
            foreach (var i in posts)
            {
                return i;
            }
            return null;
        }

        public async Task Update(Post entity)
        {
            SqlParameter title = new SqlParameter("@title", entity.Title);
            SqlParameter text = new SqlParameter("@text", entity.Text);
            SqlParameter time = new SqlParameter("@time", entity.Publicationtime);
            SqlParameter author = new SqlParameter("@author", entity.AuthorId);
            SqlParameter id = new SqlParameter("@id", entity.Id);
            await Database.Database.ExecuteSqlRawAsync("UPDATE Posts SET Title=@title, Text=@text, Publicationtime=@time, AuthorId=@author " +
                "WHERE Id LIKE @id "
                , title, text, time, author, id);
        }
    }

}
