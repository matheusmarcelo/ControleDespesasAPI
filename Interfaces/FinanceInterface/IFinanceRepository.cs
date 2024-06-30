using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;
using ControleDespesas.Pagination;

namespace ControleDespesas.Interfaces.FinanceInterface
{
    public interface IFinanceRepository
    {
        Task<IEnumerable<Finance>> GetAllAsync(); 
        Task<Finance> GetAsync(int id);
        Task CreateAsync(Finance model);
        Task<Finance> UpdateAsync(int id, Finance model);
        Task<Finance> DeleteAsync(int id);

        Task<PagedResultBase> PaginationFinances(int id, int page, int pageSize);
    }
}