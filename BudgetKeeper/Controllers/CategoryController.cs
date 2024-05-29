using BudgetKeeper.Database.Entity;
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


        [HttpGet("get-all-categorys")]
        public async Task<IActionResult> Get()
        {
            var categorys = _categoryService.GetAll();

            if (categorys.Count != 0)
                return Ok(categorys);

            return NoContent();
        }

        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var category = _categoryService.Get(id);

            if (category != null)
                return Ok(category);

            return NoContent();
        }

        [HttpGet("get-category-by-name/{name}")]
        public async Task<IActionResult> Get([FromRoute] string name)
        {
            var category = _categoryService.Get(name);

            if (category != null)
                return Ok(category);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRecord category)
        {
            if (category == null)
                return BadRequest();

            if(_categoryService.Add(category))
                return CreatedAtAction(nameof(category), new { id = category.Id}, category);

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CategoryRecord category)
        {
            if (category == null || id != category.Id)
                return BadRequest();

            if (_categoryService.Update(category))
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
