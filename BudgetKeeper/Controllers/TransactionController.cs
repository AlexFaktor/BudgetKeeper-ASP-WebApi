using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Transaction;
using BudgetKeeper.Resource.Interface;
using BudgetKeeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService, ICategoryService categoryService)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var transactions = _transactionService.GetAll();

            if (transactions.Count != 0) 
                return Ok(transactions);

            return NoContent();
        }

        [HttpGet("get-transaction/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var transaction = _transactionService.Get(id);

            if (transaction != null)
                return Ok(transaction);

            return NoContent();
        }

        [HttpGet("period")]
        public async Task<IActionResult> Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var transactions = _transactionService.Get(from, to);

            if (transactions != null && transactions.Any())
                return Ok(transactions);

            return NoContent();
        }

        [HttpGet("day")]
        public async Task<IActionResult> Get([FromQuery] DateTime day)
        {
            var transactions = _transactionService.Get(day);

            if (transactions != null && transactions.Any())
                return Ok(transactions);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionCreateDto transactionDto)
        {
            if (transactionDto is null)
                return BadRequest();

            var record = _transactionService.Add(transactionDto);

            if (record is not null)
                return CreatedAtAction(nameof(Get), new { id = record.Id, record});

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TransactionUpdateDto transactionDto)
        {
            if (transactionDto is null)
                return BadRequest();

            var record = _transactionService.Update(id ,transactionDto);

            if (record is not null)
                return Ok(record);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (_transactionService.Delete(id))
                return NoContent();

            return NotFound();
        }
    }
}
