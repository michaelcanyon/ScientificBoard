using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Coursal_IT_2020_spring.Services.Interfaces;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.ViewModels;
using MongoDB.Bson;
using Microsoft.AspNetCore.Cors;
using MongoDB.Bson.IO;

namespace Coursal_IT_2020_spring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        private readonly IPostTagService _postTagService;
        public PostController(IAccountService accountService, IPostService postService, IPostTagService postTagService)
        {
            _accountService = accountService;
            _postService = postService;
            _postTagService = postTagService;
        }

        /// <summary>
        /// Получить посты
        /// </summary>
        [HttpGet]
        [Route("posts")]
        [ProducesResponseType(typeof(List<PostViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _postService.GetPosts();
                List<PostViewModel> completePosts = new List<PostViewModel>();
                foreach (var i in posts)
                {
                    var posttags = await _postTagService.GetPostTags(i.Id);
                    List<string> Tags = new List<string>();
                    foreach (var g in posttags)
                        Tags.Add(g.Title);
                    var nickname = (await _accountService.GetAccount(i.AuthorId)).Nickname;
                    completePosts.Add(new PostViewModel { nickname = nickname, title = i.Title, text = i.Text, tags = Tags });
                }
                return Ok(completePosts);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Получить посты по автору
        /// </summary>
        [HttpGet]
        [Route("postsByAuthor")]
        [ProducesResponseType(typeof(List<PostViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostsByAuthor(string authorNickname)
        {
            try
            {
                var posts = await _postService.GetPostsByAuthor(authorNickname);
                List<PostViewModel> completePosts = new List<PostViewModel>();
                foreach (var i in posts)
                {
                    var posttags = await _postTagService.GetPostTags(i.Id);
                    List<string> Tags = new List<string>();
                    foreach (var g in posttags)
                        Tags.Add(g.Title);
                    var nickname = (await _accountService.GetAccount(i.AuthorId)).Nickname;
                    completePosts.Add(new PostViewModel { nickname = nickname, title = i.Title, text = i.Text, tags = Tags });
                }
                return Ok(completePosts);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        /// <summary>
        /// Получить посты по категории
        /// </summary>
        [HttpGet]//Swagger не позволяет передавать массив по аттрибуту GET
        [Route("postsByCategory")]
        [ProducesResponseType(typeof(List<PostViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostsByCategory(string category)
        {
            try
            {
                var posts = await _postService.GetPostsByCategory(category);
                List<PostViewModel> completePosts = new List<PostViewModel>();
                foreach (var i in posts)
                {
                    var posttags =await _postTagService.GetPostTags(i.Id);
                    List<string> Tags = new List<string>();
                    foreach (var g in posttags)
                        Tags.Add(g.Title);
                    var nickname = (await _accountService.GetAccount(i.AuthorId)).Nickname;
                    completePosts.Add(new PostViewModel { nickname = nickname, title = i.Title, text = i.Text, tags = Tags });
                }
                return Ok(completePosts);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Создать пост
        /// </summary>
        /// <param name="blog">Блог</param>
        /// <returns>Ответ сервера.</returns>
        [HttpPut]
        [Route("post")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePost([FromBody] PostViewModel Post)
        {
            try
            {
                //сформировать и вставить пост
                var author = await _accountService.GetAccount(new User { Nickname = Post.nickname, Password = Post.password });
                var post = Post.ToPostObject();
                post.AuthorId = author.Id;
                await _postService.InsertPost(post);

                //получить пост с id
                post = await _postService.GetSingle(post.Title, author.Nickname);

                //сформировать теги и получит теги с id
                foreach (var i in Post.tags)
                    await _postTagService.CreateTag(i);
                List<Tag> tags = new List<Tag>();
                foreach (var b in Post.tags)
                    tags.Add(await _postTagService.GetSingleTag(b));

                //сформировать пары ключей пост-тег
                foreach (var c in tags)
                    await _postTagService.CreatePostTagNode(post.Id, c.Id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Удалить пост
        /// </summary>
        /// <returns>Ответ сервера.</returns>
        [HttpPost]
        [Route("postDel")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] PostViewModel Post)
        {
            try
            {
                var post = await _postService.GetSingle(Post.title, Post.nickname);
                await _postTagService.DeletePostTagNodes(post.Id);
                await _postService.DeletePost(Post.title, Post.nickname);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
