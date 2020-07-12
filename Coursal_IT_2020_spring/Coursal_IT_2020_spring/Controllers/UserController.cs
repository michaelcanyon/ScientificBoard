using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Coursal_IT_2020_spring.Models;
using Coursal_IT_2020_spring.Services.Interfaces;
using Coursal_IT_2020_spring.ViewModels;

namespace Coursal_IT_2020_spring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Получить информацию по аккаунтам
        /// </summary>
        /// <param name="пользователи">пользователи</param>
        /// <returns>Ответ сервера.</returns>
        [HttpGet]
        [Route("accounts")]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var accounts= await _accountService.GetAccounts();
                return Ok(accounts);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [HttpPost]
        [Route("GetAccount")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAccount([FromBody] UserViewModel user)
        {
            try
            {
                var account = await _accountService.GetAccount(user.ToUserObject());
                if (account==null)
                    return BadRequest("Login Error!");
                    return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Добавить новый блог и пользователя
        /// </summary>
        /// <param name="пользователь">пользователь</param>
        /// <returns>Ответ сервера.</returns>
        [HttpPut]
        [Route("account")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAccount([FromBody] UserViewModel user)
        {
            try
            {
               var created = await _accountService.CreateAccount(user.ToUserObject());
                //if (!created)
                //    return BadRequest("Username is Busy");
                return Ok(user.ToUserObject());
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Удалить аккаунт
        /// </summary>
        /// <returns>Ответ сервера.</returns>
        [HttpPost]
        [Route("accountDel")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] UserViewModel user)
        {
            try
            {
                await _accountService.DeleteAccount(user.nickname, user.password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        /// <summary>
        /// Обновить аккаунт
        /// </summary>
        /// <returns>Ответ сервера.</returns>
        [HttpPost]
        [Route("account")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UserViewModel user)
        {
            try
            {
                await _accountService.Update(user.ToUserObject());
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
