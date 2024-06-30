using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Interfaces.UserInterfaces;
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
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();

            if(users.Count() <= 0 || users is null)
            {
                return NotFound("Ainda não existem usuarios cadastrados!");
            }

            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet, Route("user/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _userService.GetAsync(id);

            if(user is null)
            {
                return NotFound("Usuario Não encontrado!");
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost, Route("create-user")]
        public async Task<IActionResult> CreateAsync(User user)
        {
            await _userService.CreateAsync(user);
            
            return Ok("Usuario cadastrado com sucesso!");
        }

        [Authorize]
        [HttpPut, Route("update-user/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, User user)
        {
            var updatedUser = await _userService.UpdateAsync(id, user);

            if(updatedUser is null)
            {
                return NotFound("Usuario Não encontrado!");
            }

            return Ok(updatedUser);
        }

        [Authorize]
        [HttpDelete, Route("delete-user/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = await _userService.DeleteAsync(id);

            if(user is null)
            {
                return NotFound("Usuario Não encontrado!");
            }

            return Ok(user);
        }
    }
}