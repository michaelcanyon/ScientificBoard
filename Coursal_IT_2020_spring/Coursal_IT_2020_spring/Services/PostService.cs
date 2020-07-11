using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.Services.Interfaces;
using Coursal_IT_2020_spring.IRepositories;
using Coursal_IT_2020_spring.Infrastructures.Repositories.Interfaces;
using System.Security.Cryptography;

namespace Coursal_IT_2020_spring.Services
{
    public class PostService : IPostService
    {
       // private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IPostTagRepository _postTagRepository;
        public PostService(IPostRepository postRepository, IUserRepository userRepository, ITagRepository tagRepository, IPostTagRepository postTagRepository)
        {
         //   _blogRepository = blogRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
            _postTagRepository = postTagRepository;
        }
        public async Task DeletePost(string postTitle, string authorNickname)
        {
            Post RemovablePost = await _postRepository.GetPostByTitle(postTitle, authorNickname);
            if (RemovablePost != null)
            {
                // await _blogRepository.DeletePostFromBlog(RemovablePost);

                //перемести это в сервис для тегов
               //var _PostTags =await _postTagRepository.GetTagsIdList(RemovablePost.Id);
               // foreach (var i in _PostTags)
               // {
               //     await _postTagRepository.Delete(i);
               // }
                await _postRepository.Delete(RemovablePost);
            }
        }
        public async Task<List<Post>> GetPosts()
        {
            return await _postRepository.GetList();
        }
        public async Task<List<Post>> GetPostsByAuthor(string authorNickname)
        {
            User author = await _userRepository.GetByNickname(authorNickname);
            return await _postRepository.GetPostsByAuthor(author.Id);
        }
        public async Task<List<Post>> GetPostsByCategory(string category)
        {
             var tag= await _tagRepository.GetSingle(category);
             var postsIds= await _postTagRepository.GetPostsIdList(tag.Id);
            List<Post> posts=new List<Post>(); 
            foreach (var i in postsIds)
            {
                var post =await _postRepository.GetSingle(i.PostId);
                if(post!=null)
                    posts.Add(post);
            }
            return posts;
        }
        public async Task InsertPost(Post post)
        {
            await _postRepository.Create(post);
        }

        public async Task ReplacePostByTitle(string postTitle, string authorNickname, Post post)
        {
            var getPost = await _postRepository.GetPostByTitle(postTitle, authorNickname);
            getPost.Publicationtime = post.Publicationtime;
            getPost.Text = post.Text;
            getPost.Title = post.Title;
         //  await _blogRepository.ReplacePostByTitleInBlog(getPost);
           await _postRepository.Update(getPost);
        }
        public async Task<Post> GetSingle(string postTitle, string authorNickname)
        {
            return await _postRepository.GetPostByTitle(postTitle, authorNickname);
        }
    }
}
