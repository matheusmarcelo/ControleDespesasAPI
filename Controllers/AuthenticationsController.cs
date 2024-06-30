using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Interfaces.AuthenticationInterafaces;
using ControleDespesas.Models;
using ControleDespesas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleDespesas.Controllers
{
    [ApiController]
    [Route("v1/auth")]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost, Route("login")]
        public async Task<IActionResult> LoginAsync(Authentication authentication)
        {
            var user = await _authenticationService.LoginAsync(authentication.Email, authentication.Password);

            if(user is null)
            {
                return BadRequest("Login inválido!");
            }

            return Ok(user);
        }
    }
}