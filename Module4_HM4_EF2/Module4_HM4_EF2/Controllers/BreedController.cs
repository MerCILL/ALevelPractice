using Microsoft.AspNetCore.Mvc;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Services;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Controllers
{
    [Route("api/breeds")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly IBreedService _breedService;
        public BreedController(IBreedService breedService)
        {
            _breedService = breedService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _breedService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existingBreed = await _breedService.GetByIdAsync(id);
            if (existingBreed == null) return NotFound();
            return Ok(existingBreed);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string breedName, string categoryName)
        {
            if (string.IsNullOrEmpty(breedName)) return BadRequest("name is null or empty");
            if (string.IsNullOrEmpty(categoryName)) return BadRequest("name is null or empty");

            var breedDTO = new BreedDTO { BreedName = breedName, CategoryDTO = new CategoryDTO { CategoryName = categoryName } };

            var creationResult = await _breedService.CreateAsync(breedDTO);
            if (creationResult == false) return BadRequest("creating error");

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _breedService.DeleteAsync(id);
            if (result == false) return NotFound();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] BreedDTO breedDTO)
        {
            var updateResult = await _breedService.UpdateAsync(breedDTO);
            if (!updateResult) return NotFound();

            return Ok();
        }



    }
}
