using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mongo_games.Models;

namespace Mongo_games_.Models
{
    class JournalActions
    {
        /// <summary>
        /// Создать аккаунт(блог к нему привязанный)
        /// </summary>
        /// <param name="blogs"></param>
        /// <param name="author"></param>
        /// <param name="blogTitle"></param>
        /// <returns></returns>
        public async Task CreateAccount(IMongoCollection<Blog> blogs, User author, string blogTitle)
        {
            Blog blog1 = new Blog
            {
                Author = author,
                Posts = new List<Post>(),
                Title = blogTitle
            };
            await blogs.InsertOneAsync(blog1);
        }
        /// <summary>
        /// Добавить пост в блог
        /// </summary>
        /// <param name="blogs"></param>
        /// <param name="author"></param>
        /// <param name="newPost"></param>
        /// <returns></returns>
        public async Task AddPost(IMongoCollection<Blog> blogs, User author, Post newPost)
        {
            var filter = Builders<Blog>.Filter.Eq("Author.Nickname", author.Nickname);
            var update = Builders<Blog>.Update.AddToSet(x => x.Posts, newPost);
            var result = await blogs.UpdateOneAsync(filter, update);
        }
        /// <summary>
        /// Удалить пост из блога
        /// </summary>
        /// <param name="blogs"></param>
        /// <param name="removablePost"></param>
        /// <returns></returns>
        public async Task DeletePost(IMongoCollection<Blog> blogs, Post removablePost)
        {
            var filter = Builders<Blog>.Filter.Eq("Author.Nickname", removablePost.Author.Nickname);
            var newp = await blogs.Find(filter).ToListAsync();
            foreach (var item in newp)
            {
                foreach (var it in item.Posts)
                {
                    if (it.Title == removablePost.Title)
                    {
                        removablePost = it;
                    }
                }
            }
            var update = Builders<Blog>.Update.Pull(x => x.Posts, removablePost);
            var result = await blogs.UpdateOneAsync(filter, update);
        }
        /// <summary>
        /// Удалить аккаунт 
        /// </summary>
        /// <param name="blogs"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task DeleteAccount(IMongoCollection<Blog> blogs, User author)
        {
            var filter = Builders<Blog>.Filter.Eq("Author.Nickname", author.Nickname) & Builders<Blog>.Filter.Eq("Author.Password", author.Password);
            await blogs.DeleteOneAsync(filter);
        }
        /// <summary>
        /// Получить посты по одному автору
        /// </summary>
        /// <param name="blogs"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task GetByAuthor(IMongoCollection<Blog> blogs, User author)
        {
            var filter = Builders<Blog>.Filter.Eq("Author.Nickname", author.Nickname);
            var buff = await blogs.Find(filter).ToListAsync();
            foreach (var item in buff)
            {

                //Здесь код для вывода информации об аккаунте и названии блога

                foreach (var it in item.Posts)
                {
                   //Здесь сам вывод или сохранение постов в коллекцию 
                }
            }
        }
        /// <summary>
        /// Получить все посты
        /// </summary>
        /// <param name="blogs"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task GetRecentAll(IMongoCollection<Blog> blogs, User author)
        {
            var filter = Builders<Blog>.Filter.Empty;
            var buff = await blogs.Find(filter).ToListAsync();
            foreach (var item in buff)
            {

                //Здесь код для вывода информации об аккаунте и названии блога

                foreach (var it in item.Posts)
                {
                    //Здесь сам вывод или сохранение постов в коллекцию 
                }
            }
        }

    }
}
