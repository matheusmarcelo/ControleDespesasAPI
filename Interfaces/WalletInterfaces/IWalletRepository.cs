using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesas.Interfaces.WalletInterfaces
{
    public interface IWalletRepository
    {
        Task WalletControl(int UserId, decimal Value, string Type);
    }
}