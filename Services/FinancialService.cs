using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;
using ControleDespesas.Respositories;

namespace ControleDespesas.Services
{
    public class FinanceService
    {
        private readonly FinanceRepository _financialRepository;

        public FinanceService(FinanceRepository financialRepository)
        {
            _financialRepository = financialRepository;
        }

        public async Task<IEnumerable<Finance>> GetAllFinanceAsync()
        {
            var finances = await _financialRepository.GetAllFinanceAsync();
            return finances;
        }

        public async Task<Finance> GetFinanceAsync(int id)
        {
            var finance = await _financialRepository.GetFinanceAsync(id);
            return finance;
        }

        public async Task<string> PostFinanceAsync(Finance finance)
        {

            finance.Date = DateTime.Now;
            await _financialRepository.PostFinanceAsync(finance);

            return "Despesa lançada!";
        }

        public async Task<Finance> PutFinanceAsync(int id, Finance finance)
        {
           var financialUpdated = await _financialRepository.PutFinanceAsync(id, finance);
           return financialUpdated;
        }

        public async Task<Finance> DeleteFinanceAsync(int id)
        {
            var finance = await _financialRepository.DeleteFinanceAsync(id);
            return finance;
        }
    }
}