using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Infrastructures.Repositories;
using Coursal_IT_2020_spring.IRepositories;

namespace Coursal_IT_2020_spring.Services
{
    public class PostTagServce : IPostTagService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IPostTagRepository _postTagRepository;
        public PostTagServce(IPostRepository postRepository, IUserRepository userRepository, ITagRepository tagRepository, IPostTagRepository postTagRepository)
        {
            //   _blogRepository = blogRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
        }
        public async Task CreatePostTagNode(int postId, int tagId)
        {
           await _postTagRepository.Create(new PostTag { PostId = postId, TagId = tagId });
        }

        public  async Task CreateTag(string tag)
        {
            await _tagRepository.Create(new Tag { Title = tag });
        }

        public async Task DeletePostTagNodes(int postId)
        {
            var post= await _postRepository.GetSingle(postId);
            var notes=await _postTagRepository.GetTagsIdList(post.Id);
            foreach (var i in notes)
            {
                await _postTagRepository.Delete(i);
            }
        }

        public async Task<List<Tag>> GetPostTags(int postId)
        {
           var postTags=await _postTagRepository.GetTagsIdList(postId);
            List<Tag> tags=new List<Tag>();
            foreach (var i in postTags)
            {
               tags.Add(await _tagRepository.GetSingle(i.TagId));
            }
            return tags;
        }
        public async Task<Tag> GetSingleTag(string tag)
        {
            return await _tagRepository.GetSingle(tag);
        }
    }
}
