using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Context;
using ControleDespesas.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ControleDespesas.Respositories
{
    public class WalletRepository
    {
        private readonly AppDbContext _context;

        public WalletRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task WalletControl(int UserId, decimal Value, string Type)
        {
            var parameters = new[]
            {
                new SqlParameter("@UsuarioId", UserId),
                new SqlParameter("@Valor", Value),
                new SqlParameter("@Tipo", Type),
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC ControleCarteira @UsuarioId, @Valor, @Tipo", parameters);
        }
    }
}