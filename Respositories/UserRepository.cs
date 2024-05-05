using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Context;
using ControleDespesas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDespesas.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> GetUserByEmailAsync(string Email)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == Email);
            if(user != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> GetUserByDocumentNumberAsync(string DocumentNumber)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.DocumentNumber == DocumentNumber);
            if(user != null)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _context.User.ToListAsync();
            return users;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        public async Task PostUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            _context.SaveChanges();
        }

        public async Task<User> PutUserAsync(int id, User user)
        {
            if(id != user.UserId)
            {
                throw new Exception("Não foi possivel realizar a operação.");
            }
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            var updatedUser = await _context.User.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            return updatedUser;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == id);

            if(user is null)
            {
                throw new Exception("Usuario não encontrado");
            }

            _context.Remove(user);
            _context.SaveChanges();

            return user;
        }
    }
}