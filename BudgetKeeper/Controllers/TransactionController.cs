using BudgetKeeper.Database.Entity;
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

        [HttpGet("get-all-transactions")]
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

        [HttpGet("get-transactions/{from:datetime}-{to:datetime}")]
        public async Task<IActionResult> Get([FromRoute] DateTime from, [FromRoute] DateTime to)
        {
            var transactions = _transactionService.Get(from, to);

            if (transactions != null && transactions.Any())
                return Ok(transactions);

            return NoContent();
        }

        [HttpGet("get-day-transactions/{day:datetime}")]
        public async Task<IActionResult> Get([FromRoute] DateTime day)
        {
            var transactions = _transactionService.Get(day);

            if (transactions != null && transactions.Any())
                return Ok(transactions);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionRecord transaction)
        {
            if (transaction == null)
                return BadRequest();

            if (transaction.Category.Id == Guid.Empty)
            {
                var unknownCategory = _categoryService.Get("Unknown");
                if (unknownCategory == null)
                    return BadRequest();

                transaction.Category = unknownCategory;
                transaction.CategoryId = unknownCategory.Id;
            }
            
            if (_transactionService.Add(transaction))
                return CreatedAtAction(nameof(Get), new { id = transaction.Id }, transaction);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TransactionRecord transaction)
        {
            if (transaction == null || id != transaction.Id)
                return BadRequest();

            if (_transactionService.Update(transaction))
                return Ok(transaction);

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
