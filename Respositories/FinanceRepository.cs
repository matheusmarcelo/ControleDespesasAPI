using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Context;
using ControleDespesas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDespesas.Respositories
{
    public class FinanceRepository
    {
        private readonly AppDbContext _context;
        private readonly WalletRepository _walletRepository;

        public FinanceRepository(AppDbContext context, WalletRepository walletRepository)
        {
            _context = context;
            _walletRepository = walletRepository;
        }

        public async Task<IEnumerable<Finance>> GetAllFinanceAsync()
        {
            var finances = await _context.Finance.AsNoTracking().ToListAsync();
            return finances;
        }

        public async Task<Finance> GetFinanceAsync(int id)
        {
            var financial = await _context.Finance.AsNoTracking().FirstOrDefaultAsync<Finance>(x => x.FinanceId == id);
            return financial;
        }

        public async Task PostFinanceAsync(Finance finance)
        {
            await _context.Finance.AddAsync(finance);
            await _walletRepository.WalletControl(finance.UserId, finance.Value, finance.Type);
            await _context.SaveChangesAsync();
        }

        public async Task<Finance> PutFinanceAsync(int id, Finance finance)
        {
            if(id != finance.FinanceId)
            {
                throw new Exception("Não foi possivel realizar a operação.");
            }

            _context.Entry(finance).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var financialUpdated = await _context.Finance.AsNoTracking().FirstOrDefaultAsync<Finance>(x => x.FinanceId == finance.FinanceId);
            return financialUpdated;
        }

        public async Task<Finance> DeleteFinanceAsync(int id)
        {
            var finance = await _context.Finance.AsNoTracking().FirstOrDefaultAsync<Finance>(x => x.FinanceId == id);

            if(finance is null)
            {
                throw new Exception("Despesa não encontrada!");
            }

            _context.Remove(finance);
            await _context.SaveChangesAsync();

            return finance;
        }
    }
}