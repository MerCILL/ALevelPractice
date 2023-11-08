using Module4_HM4_EF2.DTOs;

namespace Module4_HM4_EF2.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<CategoryDTO> GetByNameAsync(string name);
        Task<bool> CreateAsync(string name);
        Task<bool> UpdateAsync(CategoryDTO item);
        Task<bool> DeleteAsync(int id);
    }
}
