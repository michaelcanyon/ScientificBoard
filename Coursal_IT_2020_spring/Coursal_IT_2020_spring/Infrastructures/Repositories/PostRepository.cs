using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using MongoDB.Driver;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Coursal_IT_2020_spring.IRepositories;

namespace Coursal_IT_2020_spring.Infrastructures
{
    /// <summary>
    /// Действия с объектом поста
    /// </summary>
    public class PostRepository:BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IMongoDatabase database) : base(database)
        {
            Collection = database.GetCollection<Post>("Posts");
        }
        public async Task<Post> GetPostByTitle(string Title, string authorNickname)
        { 
            var filter = Builders<Post>.Filter.Eq("Author.Nickname", authorNickname) & Builders<Post>.Filter.Eq("Title", Title);
            var post= await Collection.Find(filter).ToListAsync();
            foreach (var i in post)
            {
                return i;
            }
            return null;
        }
        public async Task<List<Post>> GetPostsByAuthor(User author)
        {
            var filter = Builders<Post>.Filter.Eq("Author", author);
            var buff = await Collection.Find(filter).ToListAsync();
            return buff;
        }
        public async Task<List<Post>> GetPostsByCategory(string[] category)
        {
            var filter = Builders<Post>.Filter.All("Tags", category.ToList());
            var buff = await Collection.Find(filter).ToListAsync();
            return buff;
        }
    }

}
