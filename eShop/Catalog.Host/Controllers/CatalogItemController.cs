using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogItemController : ControllerBase
    {
        private readonly ILogger<CatalogItemController> _logger;
        private readonly ICatalogItemService _catalogItemService;

        public CatalogItemController(
            ILogger<CatalogItemController> logger,
            ICatalogItemService catalogItemService)
        {
            _logger = logger;
            _catalogItemService = catalogItemService;
        }

        [HttpGet("items")]
        public async Task<IActionResult> GetByPage(int pageIndex = 1, int pageSize = 10)
        {
            var result = await _catalogItemService.GetByPageAsyncHttpGet(pageIndex, pageSize);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddCatalogItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(AddCatalogItemRequest request)
        {
            var result = await _catalogItemService.Add(request);
            return Ok(new AddCatalogItemResponse<int?>() { Id = result });
        }
    }
}
