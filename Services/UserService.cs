using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Helper;
using ControleDespesas.Interfaces;
using ControleDespesas.Interfaces.UserInterfaces;
using ControleDespesas.Models;
using ControleDespesas.Pagination;
using ControleDespesas.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControleDespesas.Services
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValidateUserAsync(User user)
        {
           var userExist = await _userRepository.GetUserByEmailAsync(user.Email);
            if(userExist)
            {
                throw new Exception("Usuario existente!");
            }

            userExist = await _userRepository.GetUserByDocumentNumberAsync(user.DocumentNumber);
            if(userExist)
            {
                throw new Exception("Usuario existente!");
            }
        }
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public UserService(IUserRepository userRepository, IUserValidator userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<User> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return user;
        }

        public async Task CreateAsync(User user)
        {
            await _userValidator.ValidateUserAsync(user);

            user.Password = user.Password.GeneratedHash();

            await _userRepository.CreateAsync(user);
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
           var updatedUser = await _userRepository.UpdateAsync(id, user);
           return updatedUser;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _userRepository.DeleteAsync(id);
            return user;
        }
    }
}