using Microsoft.AspNetCore.Mvc;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByNameAsync([FromQuery] string name)
        {
            var existingCategory = await _categoryService.GetByNameAsync(name);
            if (existingCategory == null) return NotFound();
            return Ok(existingCategory);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var existingCategory = await _categoryService.GetByIdAsync(id);
            if (existingCategory == null) return NotFound();
            return Ok(existingCategory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest("name is null or empty");

            var creationResult = await _categoryService.CreateAsync(name);
            if (creationResult == false) return BadRequest("creating error");
            return Ok(await _categoryService.GetByNameAsync(name));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result == false) return NotFound();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CategoryDTO categoryDTO)
        {
            if (categoryDTO.Id <= 0) return BadRequest();
            if (string.IsNullOrEmpty(categoryDTO.CategoryName)) return BadRequest();

            var result = await _categoryService.UpdateAsync(categoryDTO);
            if (result == false) return NotFound();
            return Ok(categoryDTO);

        }

    }
}
