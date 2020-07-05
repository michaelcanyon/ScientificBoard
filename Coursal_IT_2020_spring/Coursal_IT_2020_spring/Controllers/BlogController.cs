using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Coursal_IT_2020_spring.Services.Interfaces;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.ViewModels;

namespace Coursal_IT_2020_spring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IPostService _postService;
        public BlogController(IAccountService accountService, IPostService postService)
        {
            _accountService = accountService;
            _postService = postService;
        }

        ///// <summary>
        ///// Получить блоги
        ///// </summary>
        //[HttpGet]
        //[Route("Blogs")]
        //[ProducesResponseType(typeof(List<Blog>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Blogs()
        //{
        //    try
        //    {
        //        var blogs = await _accountService.GetBlogs();
        //        return Ok(blogs);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}

        ///// <summary>
        ///// Добавить новый блог и пользователя
        ///// </summary>
        ///// <param name="blog">Блог</param>
        ///// <returns>Ответ сервера.</returns>
        //[HttpPost]
        //[Route("CreateAccount")]
        //[ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> CreateAccount([FromBody] BlogViewModel blog)
        //{
        //    try
        //    {
        //        await _accountService.CreateAccount(blog.ToBlogObject());
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}

        /// <summary>
        /// Аккаунт с блогом по никнейму автора
        /// </summary>
        /// <returns>Аккаунт с блогом</returns>
        [HttpGet]
        [Route("singleBlog")]
        [ProducesResponseType(typeof(Blog), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSingleBlog(string authorNickname, string password)
        {
            User user = new User { Nickname = authorNickname, Password = password };
            try
            {
                var account = await _accountService.GetAccount(user);
                var posts = await _postService.GetPostsByAuthor(account.Nickname);
                var blog = new Blog { Author = account, Posts = posts };
                return Ok(blog);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        ///// <summary>
        ///// Удалить аккаунт
        ///// </summary>
        ///// <returns>Ответ сервера.</returns>
        //[HttpPost]
        //[Route("DeleteBlog/{authorNickname?}/{password?}")]
        //[ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Delete(string nickname, string password)
        //{
        //    try
        //    {
        //        await _accountService.DeleteAccount(nickname, password);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}

        ///// <summary>
        ///// Обновить блог.
        ///// </summary>
        ///// <param name="blog">Блог</param>
        ///// <returns>Ответ сервера.</returns>
        //[HttpPost]
        //[Route("UpdateBlog")]
        //[ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateBlog([FromBody] BlogViewModel blogViewModel)
        //{
        //    try
        //    {
        //        await _accountService.Update(blogViewModel.ToBlogObject());
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}
    }
}
