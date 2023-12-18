using Catalog.Host.Models.DTOs;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogBffController : ControllerBase
    {
       private readonly ILogger<CatalogBffController> _logger;
       private readonly ICatalogBffService _catalogService;

        public CatalogBffController(
            ILogger<CatalogBffController> logger, 
            ICatalogBffService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemsByPageAsync(PaginatedItemsRequest request)
        {
            var result = await _catalogService.GetCatalogItemsAsync(request.PageIndex, request.PageSize);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CatalogGetItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemByIdAsync(int id)
        {
            var result = await _catalogService.GetItemByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogGetItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemsByBrandAsync(int brandId)
        {
            var result = await _catalogService.GetItemsByBrandAsync(brandId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogGetItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemsByTypeAsync(int typeId)
        {
            var result = await _catalogService.GetItemsByTypeAsync(typeId);
            return Ok(result);
        }
        

        //Brand
        [HttpPost]
        [ProducesResponseType(typeof(CatalogBrandDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBrandByIdAsync(int id)
        {
            var result = await _catalogService.GetBrandByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBrandsByPageAsync(PaginatedItemsRequest request)
        {
            var result = await _catalogService.GetBrandsByPageAsync(request.PageIndex, request.PageSize);
            return Ok(result);
        }


        //Type
        [HttpPost]
        [ProducesResponseType(typeof(CatalogTypeDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTypeByIdAsync(int id)
        {
            var result = await _catalogService.GetTypeByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogTypeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTypesByPageAsync(PaginatedItemsRequest request)
        {
            var result = await _catalogService.GetTypesByPageAsync(request.PageIndex, request.PageSize);
            return Ok(result);
        }

    }
}
