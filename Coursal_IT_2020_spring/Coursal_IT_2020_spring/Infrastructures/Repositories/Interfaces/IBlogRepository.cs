using Coursal_IT_2020_spring.Models;
using System.Collections;
using System.Threading.Tasks;

namespace Coursal_IT_2020_spring.IRepositories
{
    /// <summary>
    /// Блог
    /// </summary>
   public interface IBlogRepository : IBaseRepository<Blog>
    {
        public Task<Blog> GetByAuthor(User author);
        public Task InsertPostIntoBlog(User author, Post post);
        public Task DeletePostFromBlog(Post post);
        public Task ReplacePostByTitleInBlog(Post post);
    }
}
