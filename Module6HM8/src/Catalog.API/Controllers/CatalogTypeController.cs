using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("/api/catalog")]
public class CatalogTypeController : ControllerBase
{
    private readonly ICatalogTypeService _catalogTypeService;
    private readonly ILogger<CatalogTypeController> _logger;

    public CatalogTypeController(
        ICatalogTypeService catalogTypeService,
        ILogger<CatalogTypeController> logger)
    {
        _catalogTypeService = catalogTypeService;
        _logger = logger;
    }

    [HttpGet("types")]
    public async Task<IActionResult> Get()
    {
        var types = await _catalogTypeService.Get();
        return Ok(types);
    }
}

