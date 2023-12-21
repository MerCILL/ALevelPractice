using Catalog.Host.Models.Requests.AddRequests;
using Catalog.Host.Models.Requests.DeleteRequests;
using Catalog.Host.Models.Requests.UpdateRequests;
using Catalog.Host.Models.Responses.AddResponses;
using Catalog.Host.Models.Responses.UpdateResponses;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route($"{ComponentDefaults.DefaultRoute}/catalog")]
    public class CatalogBrandController : ControllerBase
    {
        private readonly ILogger<CatalogBrandController> _logger;
        private readonly ICatalogBrandService _catalogBrandService;

        public CatalogBrandController(
            ILogger<CatalogBrandController> logger,
            ICatalogBrandService catalogBrandService)
        {
            _logger = logger;
            _catalogBrandService = catalogBrandService;
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrandsByPage(int pageIndex = 1, int pageSize = 10)
        {
            var result = await _catalogBrandService.GetByPageAsyncHttpGet(pageIndex, pageSize);
            return Ok(result);
        }

        [HttpPost("brands")]
        [ProducesResponseType(typeof(AddCatalogBrandResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBrand(AddCatalogBrandRequest request)
        {
            var result = await _catalogBrandService.AddAsync(request);
            return Ok(new AddCatalogBrandResponse<int?>() { Id = result });
        }

        [HttpPut("brands")]
        [ProducesResponseType(typeof(UpdateCatalogBrandResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBrand(UpdateCatalogBrandRequest request)
        {
            var result = await _catalogBrandService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("brands")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBrand(DeleteCatalogBrandRequest request)
        {
            try
            {
                await _catalogBrandService.DeleteAsync(request);
                return Ok("Brand successfully deleted");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Brand not found");
            }
        }


    }
}
