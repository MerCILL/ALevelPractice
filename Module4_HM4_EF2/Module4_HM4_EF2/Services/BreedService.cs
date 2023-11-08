using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Repositories;
using Module4_HM4_EF2.Repositories.Abstractions;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Services
{
    public class BreedService : IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        private readonly ICategoryService _categoryService;

        public BreedService(IBreedRepository breedRepository, ICategoryService categoryService)
        {
            _breedRepository = breedRepository;
            _categoryService = categoryService;
        }
        public async Task<bool> CreateAsync(BreedDTO item)
        {
            var existingCategory = await _categoryService.GetByNameAsync(item.CategoryDTO.CategoryName);
            if (existingCategory == null) return false;

            var newBreed = new Breed
            {
                BreedName = item.BreedName,
                Category = new Category
                {
                    CategoryName = item.CategoryDTO.CategoryName
                },
            };
            await _breedRepository.CreateAsync(newBreed);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _breedRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BreedDTO>> GetAllAsync()
        {
            var breeds = await _breedRepository.GetAllAsync();
            return breeds.Select(breed => new BreedDTO 
            { 
                Id = breed.Id, 
                BreedName = breed.BreedName,
                CategoryDTO = new CategoryDTO 
                { 
                    Id = breed.CategoryId, 
                    CategoryName = breed.Category.CategoryName 
                } 
            });
        }

        public async Task<BreedDTO> GetByIdAsync(int id)
        {
            var existingBreed = await _breedRepository.GetByIdAsync(id);
            if (existingBreed != null) return new BreedDTO
            {
                Id = existingBreed.Id,
                BreedName = existingBreed.BreedName,
                CategoryDTO = existingBreed.Category == null ? null : new CategoryDTO
                {
                    Id = existingBreed.Category.Id,
                    CategoryName = existingBreed.Category.CategoryName
                }
            };
            return null;
        }

        public async Task<BreedDTO> GetByNameAsync(string name)
        {
            var existingBreed = await _breedRepository.GetByNameAsync(name);

            if (existingBreed == null) return null;

            return new BreedDTO { Id = existingBreed.Id, BreedName = existingBreed.BreedName };
        }

        public async Task<bool> UpdateAsync(BreedDTO item)
        {
            var existingBreed = await _breedRepository.GetByIdAsync(item.Id);
            if (existingBreed == null) return false;

            existingBreed.BreedName = item.BreedName;
            existingBreed.Category.CategoryName = item.CategoryDTO.CategoryName;
          

            return await _breedRepository.UpdateAsync(existingBreed);
        }
    }
}
