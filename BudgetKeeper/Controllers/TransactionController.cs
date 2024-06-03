using BudgetKeeper.Core.TransactionDtos;
using BudgetKeeper.Resource.Interface;
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
            var transactions = await _transactionService.GetAllAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var transaction = await _transactionService.GetAsync(id);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpGet("period")]
        public async Task<IActionResult> Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var transactions = await _transactionService.GetAsync(from, to);

            return Ok(transactions);
        }

        [HttpGet("day")]
        public async Task<IActionResult> Get([FromQuery] DateTime day)
        {
            var transactions = await _transactionService.GetAsync(day);

            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionCreateDto transactionDto)
        {
            if (transactionDto is null)
                return BadRequest();

            var record = await _transactionService.AddAsync(transactionDto);

            if (record is null)
                return BadRequest();

            return CreatedAtAction(nameof(Get), new { id = record.Id }, record);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TransactionUpdateDto transactionDto)
        {
            if (transactionDto is null)
                return BadRequest();

            var record = await _transactionService.UpdateAsync(id, transactionDto);

            if (record is null)
                return NotFound();

            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (await _transactionService.DeleteAsync(id))
                return NoContent();

            return NotFound();
        }
    }
}
