using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;

namespace Coursal_IT_2020_spring.Services.Interfaces
{
    public interface IPostTagService
    {
        public Task CreateTag(string tag);
        public Task CreatePostTagNode(int postId, int TagId);
        public Task<List<Tag>> GetPostTags(int postId);
        public Task DeletePostTagNodes(int postId);
        public Task<Tag> GetSingleTag(string tag);
    }
}
