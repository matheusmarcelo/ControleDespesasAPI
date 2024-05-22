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
    public class FinancialsController : ControllerBase
    {
        private readonly FinancialService _financialService;

        public FinancialsController(FinancialService financialService)
        {
            _financialService = financialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFinancialAsync()
        {
            var finances = await _financialService.GetAllFinancialAsync();

            if(finances.Count() <= 0 || finances is null)
            {
                return NotFound("Ainda não existem despesas cadastradas!");
            }

            return Ok(finances);
        }

        [HttpGet, Route("finance/{id}")]
        public async Task<IActionResult> GetFinancialAsync(int id)
        {
            var finance = await _financialService.GetFinancialAsync(id);

            if(finance is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(finance);
        }

        [HttpPost, Route("create-finance")]
        public async Task<IActionResult> PostFinancialAsync(Finance finance)
        {
            var result = await _financialService.PostFinancialAsync(finance);
            
            return Ok(result);
        }

        [HttpPut, Route("update-finance/{id}")]
        public async Task<IActionResult> PutFinancialAsync(int id, Finance finance)
        {
            var financeUpdated = await _financialService.PutFinancialAsync(id, finance);

            if(financeUpdated is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(financeUpdated);
        }

        [HttpDelete, Route("delete-finance/{id}")]
        public async Task<IActionResult> DeleteFinancialAsync(int id)
        {
            var finance = await _financialService.DeleteFinancialAsync(id);

            if(finance is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(finance);
        }
    }
}