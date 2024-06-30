using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;

namespace ControleDespesas.Interfaces.UserInterfaces
{
    public interface IUserValidator
    {
        Task ValidateUserAsync(User user);
    }
}