using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;

namespace ControleDespesas.Interfaces.AuthenticationInterafaces
{
    public interface IAuthenticationRepository
    {
        Task<User> LoginAsync(string email, string password);
    }
}