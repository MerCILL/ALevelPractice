using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services.Interfaces;

namespace MVC.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 3)
        {
            var items = await _catalogService.GetCatalogItemsAsync2(pageIndex, pageSize);
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)items.Count / pageSize);
            return View(items.Data);
        }

        public async Task<IActionResult> CatalogItems(int pageIndex = 1, int pageSize = 3)
        {
            var items = await _catalogService.GetCatalogItemsAsync2(pageIndex, pageSize);
            return PartialView("_CatalogItems", items);
        }

    }
}
