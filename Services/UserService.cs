using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;
using ControleDespesas.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControleDespesas.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return user;
        }

        public async Task PostUserAsync(User user)
        {
            var userExist = await _userRepository.GetUserByEmailAsync(user.Email);
            if(userExist)
            {
                throw new Exception("Já existe um usuario com este email!");
            }

            userExist = await _userRepository.GetUserByDocumentNumberAsync(user.DocumentNumber);
            if(userExist)
            {
                throw new Exception("Este usuario já possui uma conta!");
            }

            await _userRepository.PostUserAsync(user);
        }

        public async Task<User> PutUserAsync(int id, User user)
        {
           var updatedUser = await _userRepository.PutUserAsync(id, user);
           return updatedUser;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _userRepository.DeleteUserAsync(id);
            return user;
        }
    }
}