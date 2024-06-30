using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Interfaces.FinanceInterface;
using ControleDespesas.Models;
using ControleDespesas.Pagination;
using ControleDespesas.Respositories;

namespace ControleDespesas.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IFinanceRepository _financialRepository;

        public FinanceService(IFinanceRepository financialRepository)
        {
            _financialRepository = financialRepository;
        }

        public async Task<IEnumerable<Finance>> GetAllAsync()
        {
            var finances = await _financialRepository.GetAllAsync();
            return finances;
        }

        public async Task<Finance> GetAsync(int id)
        {
            var finance = await _financialRepository.GetAsync(id);
            return finance;
        }

        public async Task CreateAsync(Finance finance)
        {

            finance.Date = DateTime.Now;
            await _financialRepository.CreateAsync(finance);
        }

        public async Task<Finance> UpdateAsync(int id, Finance finance)
        {
           var financialUpdated = await _financialRepository.UpdateAsync(id, finance);
           return financialUpdated;
        }

        public async Task<Finance> DeleteAsync(int id)
        {
            var finance = await _financialRepository.DeleteAsync(id);
            return finance;
        }

        public async Task<PagedResultBase> PaginationFinances(int id, int page, int pageSize)
        {
            var pagination = await _financialRepository.PaginationFinances(id, page, pageSize);
            return pagination;
        }
    }
}