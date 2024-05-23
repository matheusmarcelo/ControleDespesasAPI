using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Models;
using ControleDespesas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDespesas.Controllers
{
    [ApiController]
    [Route("v1/finances")]
    [Authorize]
    public class FinancesController : ControllerBase
    {
        private readonly FinanceService _financeService;

        public FinancesController(FinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFinanceAsync()
        {
            var finances = await _financeService.GetAllFinanceAsync();

            if(finances.Count() <= 0 || finances is null)
            {
                return NotFound("Ainda não existem despesas cadastradas!");
            }

            return Ok(finances);
        }

        [HttpGet, Route("finance/{id}")]
        public async Task<IActionResult> GetFinanceAsync(int id)
        {
            var finance = await _financeService.GetFinanceAsync(id);

            if(finance is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(finance);
        }

        [HttpPost, Route("create-finance")]
        public async Task<IActionResult> PostFinanceAsync(Finance finance)
        {
            var result = await _financeService.PostFinanceAsync(finance);
            
            return Ok(result);
        }

        [HttpPut, Route("update-finance/{id}")]
        public async Task<IActionResult> PutFinanceAsync(int id, Finance finance)
        {
            var financeUpdated = await _financeService.PutFinanceAsync(id, finance);

            if(financeUpdated is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(financeUpdated);
        }

        [HttpDelete, Route("delete-finance/{id}")]
        public async Task<IActionResult> DeleteFinanceAsync(int id)
        {
            var finance = await _financeService.DeleteFinanceAsync(id);

            if(finance is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(finance);
        }
    }
}