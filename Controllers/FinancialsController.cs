using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesas.Interfaces.FinanceInterface;
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
        private readonly IFinanceService _financeService;

        public FinancesController(IFinanceService financeService)
        {
            _financeService = financeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var finances = await _financeService.GetAllAsync();

            if(finances.Count() <= 0 || finances is null)
            {
                return NotFound("Ainda não existem despesas cadastradas!");
            }

            return Ok(finances);
        }

        [HttpGet, Route("finance/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var finance = await _financeService.GetAsync(id);

            if(finance is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(finance);
        }

        [HttpPost, Route("create-finance")]
        public async Task<IActionResult> CreateAsync(Finance finance)
        {
            await _financeService.CreateAsync(finance);
            
            return Ok("Lançamento cadastrado com sucesso!");
        }

        [HttpPut, Route("update-finance/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Finance finance)
        {
            var financeUpdated = await _financeService.UpdateAsync(id, finance);

            if(financeUpdated is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(financeUpdated);
        }

        [HttpDelete, Route("delete-finance/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var finance = await _financeService.DeleteAsync(id);

            if(finance is null)
            {
                return NotFound("Despesa não encontrada!");
            }

            return Ok(finance);
        }


        [AllowAnonymous]
        [HttpGet, Route("pagination-finances/{id:int}/{page:int}/{pageSize:int}")]
        public async Task<IActionResult> PaginationFinances(int id, int page, int pageSize)
        {
            var paginantion = await _financeService.PaginationFinances(id, page, pageSize);

            if(paginantion.RowCount == 0)
            {
                return BadRequest("Você ainda não possui lançamentos!");
            }

            return Ok(paginantion);
        }
    }
}