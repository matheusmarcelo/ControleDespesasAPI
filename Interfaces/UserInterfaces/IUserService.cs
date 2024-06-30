using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;

namespace ControleDespesas.Interfaces.UserInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync(); 
        Task<User> GetAsync(int id);
        Task CreateAsync(User model);
        Task<User> UpdateAsync(int id, User model);
        Task<User> DeleteAsync(int id);
    }
}