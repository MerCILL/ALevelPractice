﻿using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests.AddRequests;
using Catalog.Host.Models.Requests.DeleteRequests;
using Catalog.Host.Models.Requests.UpdateRequests;
using Catalog.Host.Models.Responses.AddResponses;
using Catalog.Host.Models.Responses.UpdateResponses;
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

        [HttpPut]
        [ProducesResponseType(typeof(UpdateCatalogItemResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateItem(UpdateCatalogItemRequest request)
        {
            var result = await _catalogItemService.Update(request);
            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItem(DeleteCatalogItemRequest request)
        {
            try
            {
                await _catalogItemService.Delete(request);
                return Ok("Item successfully deleted");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Item not found");
            }
        }
    }
}
