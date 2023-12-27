using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MVC.Models;
using MVC.Services.Interfaces;

namespace MVC.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly AppSettings _appSettings;

        public CatalogService(IHttpClientService httpClientService, IOptions<AppSettings> appSettings)
        {
            _httpClientService = httpClientService;
            _appSettings = appSettings.Value;
        }

        public async Task<Catalog> GetCatalogItemsAsync(PaginatedItemsRequest request)
        {
            var url = $"{_appSettings.CatalogUrl}/items";
            return await _httpClientService.SendAsync<Catalog, PaginatedItemsRequest>(url, HttpMethod.Get, request);
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            var url = $"{_appSettings.CatalogUrl}/brands";
            var response = await _httpClientService.SendAsync<Brand, object>(url, HttpMethod.Get, null);
            var brands = response.Data;
            return brands.Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Brand });
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var url = $"{_appSettings.CatalogUrl}/types";
            var response = await _httpClientService.SendAsync<Models.Type, object>(url, HttpMethod.Get, null);
            var types = response.Data;
            return types.Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Type });
        }
    }
}
