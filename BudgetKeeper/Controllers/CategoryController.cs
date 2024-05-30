using BudgetKeeper.Database.Entity;
using BudgetKeeper.Models.DTO.Category;
using BudgetKeeper.Resource.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
            var categorys = _categoryService.GetAll();

            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var category = _categoryService.Get(id);

            if (category != null)
                return Ok(category);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryDto)
        {
            if (categoryDto is null)
                return BadRequest();

            if (_categoryService.Add(categoryDto))
                return CreatedAtAction(nameof(Get), new { id = categoryDto.Name }, categoryDto);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CategoryUpdateDto category)
        {
            if (category == null)
                return BadRequest();

            if (_categoryService.Update(id, category))
                return Ok(category);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (_categoryService.Delete(id))
                return NoContent();

            return BadRequest();    
        }
    }
}
