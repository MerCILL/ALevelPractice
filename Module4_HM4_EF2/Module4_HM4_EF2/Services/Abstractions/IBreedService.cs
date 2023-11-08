using Module4_HM4_EF2.DTOs;

namespace Module4_HM4_EF2.Services.Abstractions
{
    public interface IBreedService
    {
        Task<IEnumerable<BreedDTO>> GetAllAsync();
        Task<BreedDTO> GetByIdAsync(int id);
        Task<BreedDTO> GetByNameAsync(string name);
        Task<bool> CreateAsync(BreedDTO item);
        Task<bool> UpdateAsync(BreedDTO item);
        Task<bool> DeleteAsync(int id);
    }
}
