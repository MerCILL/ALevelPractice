using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Repositories.Abstractions;

namespace Module4_HM4_EF2.Services.Abstractions
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDTO>> GetAllAsync();
        Task<LocationDTO> GetByIdAsync(int id);
        Task<LocationDTO> GetByNameAsync(string name);
        Task<bool> CreateAsync(string name);
        Task<bool> UpdateAsync(LocationDTO item);
        Task<bool> DeleteAsync(int id);
    }
}
