using Module4_HM4_EF2.DTOs;

namespace Module4_HM4_EF2.Services.Abstractions
{
    public interface IPetService
    {
        Task<IEnumerable<PetDTO>> GetAllAsync();
        Task<PetDTO> GetByIdAsync(int id);
        Task<bool> CreateAsync(PetDTO petDTO);
        Task<bool> UpdateAsync(PetDTO item);
        Task<bool> DeleteAsync(int id);
    }
}
