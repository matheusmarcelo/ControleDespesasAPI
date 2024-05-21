using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Helper;
using ControleDespesas.Respositories;

namespace ControleDespesas.Services
{
    public class AuthenticationService
    {
       private readonly AuthenticationRepository _authenticationRepository;

        public AuthenticationService(AuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<dynamic> LoginAsync(string email, string password)
        {
            password = password.GeneratedHash();
            var user = await _authenticationRepository.LoginAsync(email, password);

            if(user is null)
            {
                return null;
            }

           var token = Helper.Helper.GenerateToken(user);

            var result = new 
            {
                id = user.UserId,
                code = user.DocumentNumber,
                name = user.Name,
                email = user.Email,
                access_token = token
            };

            return result;
        }
    }
}