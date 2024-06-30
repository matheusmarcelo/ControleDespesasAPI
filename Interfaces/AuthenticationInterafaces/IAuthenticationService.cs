using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;

namespace ControleDespesas.Interfaces.AuthenticationInterafaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(string email, string password);
        Task<User> VerifyLoginUser(string email, string password);
    }
}