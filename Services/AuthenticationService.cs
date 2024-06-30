using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Helper;
using ControleDespesas.Interfaces.AuthenticationInterafaces;
using ControleDespesas.Models;
using ControleDespesas.Respositories;

namespace ControleDespesas.Services
{
    public class AuthenticationService: IAuthenticationService
    {
       private readonly IAuthenticationRepository _authentication;

        public AuthenticationService(IAuthenticationRepository authentication)
        {
            _authentication = authentication;
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            password = password.GeneratedHash();
            var user = await VerifyLoginUser(email, password);

           var token = Helper.Helper.GenerateToken(user);

            var result = new LoginResponse
            {
                Id = user.UserId,
                Code = user.DocumentNumber,
                Name = user.Name,
                Email = user.Email,
                Access_token = token
            };

            return result;
        }

        public async Task<User> VerifyLoginUser(string email, string password)
        {
            var user = await _authentication.LoginAsync(email, password);

            if(user is null)
            {
               throw new Exception("Login inválido!");
            }

            return user;
        }
    }
}