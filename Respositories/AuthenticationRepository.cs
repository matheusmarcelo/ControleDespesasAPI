using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Context;
using ControleDespesas.Interfaces.AuthenticationInterafaces;
using ControleDespesas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDespesas.Respositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _context;

        public AuthenticationRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync<User>(x => x.Email == email && x.Password == password);

            if(user is null)
            {
                return null;
            }

            return user;
        }
    }
}