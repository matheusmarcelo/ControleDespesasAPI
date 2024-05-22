using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;
using ControleDespesas.Respositories;

namespace ControleDespesas.Services
{
    public class FinancialService
    {
        private readonly FinancialRepository _financialRepository;

        public FinancialService(FinancialRepository financialRepository)
        {
            _financialRepository = financialRepository;
        }

        public async Task<IEnumerable<Finance>> GetAllFinancialAsync()
        {
            var finances = await _financialRepository.GetAllFinancialAsync();
            return finances;
        }

        public async Task<Finance> GetFinancialAsync(int id)
        {
            var finance = await _financialRepository.GetFinancialAsync(id);
            return finance;
        }

        public async Task<string> PostFinancialAsync(Finance finance)
        {

            await _financialRepository.PostFinancialAsync(finance);

            return "Usuario cadastrado com sucesso!";
        }

        public async Task<Finance> PutFinancialAsync(int id, Finance finance)
        {
           var financialUpdated = await _financialRepository.PutFinancialAsync(id, finance);
           return financialUpdated;
        }

        public async Task<Finance> DeleteFinancialAsync(int id)
        {
            var finance = await _financialRepository.DeleteFinancialAsync(id);
            return finance;
        }
    }
}