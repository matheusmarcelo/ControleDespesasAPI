using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Context;
using ControleDespesas.Interfaces.FinanceInterface;
using ControleDespesas.Interfaces.WalletInterfaces;
using ControleDespesas.Models;
using ControleDespesas.Pagination;
using Microsoft.EntityFrameworkCore;

namespace ControleDespesas.Respositories
{
    public class FinanceRepository : IFinanceRepository
    {
        private readonly AppDbContext _context;
        private readonly IWalletRepository _walletRepository;

        public FinanceRepository(AppDbContext context, IWalletRepository walletRepository)
        {
            _context = context;
            _walletRepository = walletRepository;
        }

        public async Task<IEnumerable<Finance>> GetAllAsync()
        {
            var finances = await _context.Finance.AsNoTracking().ToListAsync();
            return finances;
        }

        public async Task<Finance> GetAsync(int id)
        {
            var financial = await _context.Finance.AsNoTracking().FirstOrDefaultAsync<Finance>(x => x.FinanceId == id);
            return financial;
        }

        public async Task CreateAsync(Finance finance)
        {
            await _context.Finance.AddAsync(finance);
            await _walletRepository.WalletControl(finance.UserId, finance.Value, finance.Type);
            await _context.SaveChangesAsync();
        }

        public async Task<Finance> UpdateAsync(int id, Finance finance)
        {
            if(id != finance.FinanceId)
            {
                throw new ArgumentNullException("Não foi possivel realizar a operação.");
            }

            _context.Entry(finance).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var financialUpdated = await _context.Finance.AsNoTracking().FirstOrDefaultAsync<Finance>(x => x.FinanceId == finance.FinanceId);
            return financialUpdated;
        }

        public async Task<Finance> DeleteAsync(int id)
        {
            var finance = await _context.Finance.AsNoTracking().FirstOrDefaultAsync<Finance>(x => x.FinanceId == id);

            if(finance is null)
            {
                throw new ArgumentNullException("Despesa não encontrada!");
            }

            _context.Remove(finance);
            await _context.SaveChangesAsync();

            return finance;
        }

        public async Task<PagedResultBase> PaginationFinances(int id, int page, int pageSize)
        {
            var pagination = _context.Finance.Where(f => f.UserId == id).GetPaged(page, pageSize);
            return pagination;
        }
    }
}