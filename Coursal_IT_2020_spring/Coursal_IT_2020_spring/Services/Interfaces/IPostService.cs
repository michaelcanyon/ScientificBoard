using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;

namespace Coursal_IT_2020_spring.Services.Interfaces
{
   public interface IPostService
    {
        public Task<List<Post>> GetPosts();
        public Task<List<Post>> GetPostsByAuthor(string authorNickname);
        public Task<List<Post>> GetPostsByCategory(string[] categories);
        public Task InsertPost(Post post);
        public Task DeletePost(string postTitle, string authorNIckname);
        public Task ReplacePostByTitle(string postTitle, string authorNickname, Post post);
    }
}
