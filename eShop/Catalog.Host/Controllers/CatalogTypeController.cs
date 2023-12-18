using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
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

    }
}
