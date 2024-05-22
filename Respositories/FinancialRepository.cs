using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Context;
using ControleDespesas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDespesas.Respositories
{
    public class FinancialRepository
    {
        private readonly AppDbContext _context;

        public FinancialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Finance>> GetAllFinancialAsync()
        {
            var finances = await _context.Finance.AsNoTracking().ToListAsync();
            return finances;
        }

        public async Task<Finance> GetFinancialAsync(int id)
        {
            var financial = await _context.Finance.AsNoTracking().FirstOrDefaultAsync<Finance>(x => x.FinanceId == id);
            return financial;
        }

        public async Task PostFinancialAsync(Finance finance)
        {
            await _context.Finance.AddAsync(finance);
            await _context.SaveChangesAsync();
        }

        public async Task<Finance> PutFinancialAsync(int id, Finance finance)
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

        public async Task<Finance> DeleteFinancialAsync(int id)
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