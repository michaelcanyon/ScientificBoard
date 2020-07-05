using System.Collections.Generic;
using System.Linq;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.IRepositories;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using System.Threading.Tasks;
using System.IO;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Microsoft.Extensions.Configuration;

namespace Coursal_IT_2020_spring.Infrastructures
{
    /// <summary>
    /// Действия с объектами блога
    /// </summary>
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        //private IMongoCollection<Blog> Collection.;
        
        public BlogRepository(IMongoDatabase database):base(database)
        {
            Collection = database.GetCollection<Blog>("Blogs");
            //Доступ к хранилищу
            //Collection. = db.GetCollection<Blog>(settings.DBCollection);
        }
        public async Task<Blog> GetByAuthor(User author)
        {
            var filter = Builders<Blog>.Filter.Eq("Author", author);
            //сделать так, чтобы возвращалось одно значение
            var buff = await Collection.Find(filter).ToListAsync();
            foreach (var i in buff)
            {
                return i;
            }
            return null;
        }

        public async Task InsertPostIntoBlog(User author, Post post)
        {
            var filter = Builders<Blog>.Filter.Eq("Author", author);
            var update = Builders<Blog>.Update.AddToSet(x => x.Posts, post);
            var result = await Collection.UpdateOneAsync(filter, update);
        }

        public async Task DeletePostFromBlog(Post post)
        {
            var filter = Builders<Blog>.Filter.Eq("Author", post.Author);
            var newp = await Collection.Find(filter).ToListAsync();
            foreach (var item in newp)
            {
                foreach (var it in item.Posts)
                {
                    if (it.Title == post.Title)
                    {
                        post = it;
                    }
                }
            }
            var update = Builders<Blog>.Update.Pull(x => x.Posts, post);
            var result = await Collection.UpdateOneAsync(filter, update);
        }

        public async Task ReplacePostByTitleInBlog(Post post)
        {
            Post _removablePost = post;
            var filter = Builders<Blog>.Filter.Eq("Author", post.Author);
            var newp = await Collection.Find(filter).ToListAsync();
            foreach (var item in newp)
            {
                foreach (var it in item.Posts)
                {
                    if (it.Title == post.Title)
                    {
                        _removablePost = it;
                        break;
                    }
                }
            }
            var update = Builders<Blog>.Update.Pull(x => x.Posts, _removablePost);
            var result = await Collection.UpdateOneAsync(filter, update);
            update = Builders<Blog>.Update.AddToSet(x => x.Posts, post);
            result = await Collection.UpdateOneAsync(filter, update);
        }
    }
}
