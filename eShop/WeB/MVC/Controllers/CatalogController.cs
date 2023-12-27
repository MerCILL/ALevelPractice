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
        public async Task<IActionResult> Index(int? brandFilterApplied, int? typesFilterApplied, int? page, int? itemsPage)
        {
            page ??= 1; 
            itemsPage ??= 6; 

            var request = new PaginatedItemsRequest
            {
                PageIndex = page.Value,
                PageSize = itemsPage.Value,
                BrandId = brandFilterApplied,
                TypeId = typesFilterApplied
            };

            var catalog = await _catalogService.GetCatalogItemsAsync(request);
        
            if (catalog == null || catalog.Data.Count == 0)
            {
                return View("Error");
            }

            var info = new PaginationInfo()
            {
                ActualPage = page.Value,
                ItemsPerPage = catalog.Data.Count,
                TotalItems = catalog.Count,
                TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsPage.Value)
            };

            var vm = new IndexViewModel()
            {
                CatalogItems = catalog.Data,
                Brands = await _catalogService.GetBrandsAsync(),
                Types = await _catalogService.GetTypesAsync(),
                PaginationInfo = info
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            return View(vm);
        }
    }
}
