﻿using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Microsoft.EntityFrameworkCore;
using Catalog.Host.Models.Requests.AddRequests;
using Catalog.Host.Models.Requests.UpdateRequests;
using Catalog.Host.Models.Requests.DeleteRequests;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<PaginatedItems<CatalogType>> GetTypesByPageAsync(int pageIndex, int pageSize);
        Task<CatalogType> GetTypeByIdAsync(int id);

        Task<PaginatedItems<CatalogType>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
        Task<int?> Add(AddCatalogTypeRequest typeToAdd);
        Task<CatalogType> Update(UpdateCatalogTypeRequest typeToUpdate);
        Task Delete(DeleteCatalogTypeRequest typeToDelete);

    }
}
