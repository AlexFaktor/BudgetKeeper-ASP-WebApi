using BudgetKeeper.Core.CategoryDtos;
using BudgetKeeper.Resource.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BudgetKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var categorys = await _categoryService.GetAllAsync();

            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var category = await _categoryService.GetAsync(id);

            if (category != null)
                return Ok(category);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto)
        {
            if (categoryDto is null)
                return BadRequest();

            var record = await _categoryService.AddAsync(categoryDto);

            if (record is not null)
                return CreatedAtAction(nameof(Get), new { id = record.Id }, record);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CategoryUpdateDto category)
        {
            if (category == null)
                return BadRequest();

            var record = await _categoryService.UpdateAsync(id, category);

            if (record is not null)
                return Ok(record);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (await _categoryService.DeleteAsync(id))
                return NoContent();

            return BadRequest();
        }
    }
}
