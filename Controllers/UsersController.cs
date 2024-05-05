using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;
using ControleDespesas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDespesas.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            if(users.Count() <= 0 || users is null)
            {
                return NotFound("Ainda não existem usuarios cadastrados!");
            }

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet, Route("user/{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            var user = await _userService.GetUserAsync(id);

            if(user is null)
            {
                return NotFound("Usuario Não encontrado!");
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost, Route("create-user")]
        public async Task<IActionResult> PostUserAsync(User user)
        {
            await _userService.PostUserAsync(user);
            return Ok("Usuario cadastrado com sucesso!");
        }

        [AllowAnonymous]
        [HttpPut, Route("update-user/{id}")]
        public async Task<IActionResult> PutUserAsync(int id, User user)
        {
            var updatedUser = await _userService.PutUserAsync(id, user);

            if(updatedUser is null)
            {
                return NotFound("Usuario Não encontrado!");
            }

            return Ok(updatedUser);
        }

        [AllowAnonymous]
        [HttpDelete, Route("delete-user/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _userService.DeleteUserAsync(id);

            if(user is null)
            {
                return NotFound("Usuario Não encontrado!");
            }

            return Ok(user);
        }
    }
}