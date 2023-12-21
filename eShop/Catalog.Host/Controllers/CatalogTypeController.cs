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
    public class CatalogTypeController : ControllerBase
    {
        private readonly ILogger<CatalogTypeController> _logger;
        private readonly ICatalogTypeService _catalogTypeService;

        public CatalogTypeController(
            ILogger<CatalogTypeController> logger,
            ICatalogTypeService catalogTypeService)
        {
            _logger = logger;
            _catalogTypeService = catalogTypeService;
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypesByPage(int pageIndex = 1, int pageSize = 10)
        {
            var result = await _catalogTypeService.GetByPageAsyncHttpGet(pageIndex, pageSize);
            return Ok(result);
        }

        [HttpPost("types")]
        [ProducesResponseType(typeof(AddCatalogTypeResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddType(AddCatalogTypeRequest request)
        {
            var result = await _catalogTypeService.AddAsync(request);
            return Ok(new AddCatalogTypeResponse<int?>() { Id = result });
        }

        [HttpPut("types")]
        [ProducesResponseType(typeof(UpdateCatalogTypeResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateType(UpdateCatalogTypeRequest request)
        {
            var result = await _catalogTypeService.UpdateAsync(request);
            return Ok(result);
        }

        [HttpDelete("types")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteType(DeleteCatalogTypeRequest request)
        {
            try
            {
                await _catalogTypeService.DeleteAsync(request);
                return Ok("Type successfully deleted");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Type not found");
            }
        }

    }
}
