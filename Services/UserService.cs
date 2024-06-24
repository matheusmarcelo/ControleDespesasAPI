using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Helper;
using ControleDespesas.Models;
using ControleDespesas.Pagination;
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

        public async Task<string> PostUserAsync(User user)
        {
            var userExist = await _userRepository.GetUserByEmailAsync(user.Email);
            if(userExist)
            {
                return "Já existe um usuario com este email!";
            }

            userExist = await _userRepository.GetUserByDocumentNumberAsync(user.DocumentNumber);
            if(userExist)
            {
                return "Este usuario já possui uma conta!";
            }

            user.Password = user.Password.GeneratedHash();

            await _userRepository.PostUserAsync(user);

            return "Usuario cadastrado com sucesso!";
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

        public async Task<PagedResult<User>> GetPagedUsers(int page, int pageSize)
        {
            var users = await _userRepository.GetPagedUsers(page, pageSize);
            return users;
        }
    }
}