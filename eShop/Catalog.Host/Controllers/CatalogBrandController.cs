using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
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


    }
}
