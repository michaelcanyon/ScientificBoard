//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Options;
//using MongoDB.Driver;
//using Coursal_IT_2020_spring.Models;

//namespace Coursal_IT_2020_spring
//{
//    public class BlogContext: IBlogContext
//    {
//        private readonly IMongoDatabase _db;
//        public BlogContext(IOptions<JournalDBSettings> options)
//        {
//            var client = new MongoClient(options.Value.ConnectionString);
//            _db = client.GetDatabase(options.Value.DatabaseName);
//        }
//        public IMongoCollection<Blog> Blogs => _db.GetCollection<Blog>("Blogs");
//    }
//}
