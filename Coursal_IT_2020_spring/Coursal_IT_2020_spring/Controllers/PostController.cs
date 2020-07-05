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

namespace Coursal_IT_2020_spring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        public PostController(IAccountService accountService, IPostService postService)
        {
            _accountService = accountService;
            _postService = postService;
        }

        /// <summary>
        /// Получить посты
        /// </summary>
        [HttpGet]
        [Route("posts")]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _postService.GetPosts();
                return Ok(posts);
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
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostsByAuthor(string authorNickname)
        {
            try
            {
                var posts = await _postService.GetPostsByAuthor(authorNickname);
                return Ok(posts);
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
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostsByCategory([FromQuery(Name = "category")] string[] category)
        {
            try
            {
                var posts = await _postService.GetPostsByCategory(category);
                return Ok(posts);
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
                await _postService.InsertPost(Post.ToPostObject());
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
