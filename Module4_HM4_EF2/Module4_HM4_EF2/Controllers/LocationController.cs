using Microsoft.AspNetCore.Mvc;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByNameAsync([FromQuery] string name)
        {
            var existingLocation = await _locationService.GetByNameAsync(name);
            if (existingLocation == null) return NotFound();
            return Ok(existingLocation);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var existingLocation = await _locationService.GetByIdAsync(id);
            if (existingLocation == null) return NotFound();
            return Ok(existingLocation);
        }  

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _locationService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest("name is null or empty");

            var creationResult = await _locationService.CreateAsync(name);
            if (creationResult == false) return BadRequest("creating error");
            return Ok(await _locationService.GetByNameAsync(name));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _locationService.DeleteAsync(id);
            if (result == false) return NotFound();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(LocationDTO locationDTO)
        {
            if (locationDTO.Id <= 0) return BadRequest();
            if (string.IsNullOrEmpty(locationDTO.LocationName)) return BadRequest();

            var result = await _locationService.UpdateAsync(locationDTO);
            if (result == false) return NotFound();
            return Ok(locationDTO);

        }

    }
}
