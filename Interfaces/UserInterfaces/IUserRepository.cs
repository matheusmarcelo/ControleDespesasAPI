using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;

namespace ControleDespesas.Interfaces.UserInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(); 
        Task<User> GetAsync(int id);
        Task CreateAsync(User model);
        Task<User> UpdateAsync(int id, User model);
        Task<User> DeleteAsync(int id);
        Task<bool> GetUserByEmailAsync(string email);
        Task<bool> GetUserByDocumentNumberAsync(string documentNumber);
    }
}