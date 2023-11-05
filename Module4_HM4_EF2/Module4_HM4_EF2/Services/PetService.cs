using Module4_HM4_EF2.DbData.Models;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Repositories;
using Module4_HM4_EF2.Repositories.Abstractions;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;
        private readonly IBreedService _breedService;

        public PetService(IPetRepository petRepository, ILocationService locationService, ICategoryService categoryService, IBreedService breedService)
        {
            _petRepository = petRepository;
            _locationService = locationService;
            _categoryService = categoryService;
            _breedService = breedService;
        }

        public async Task<bool> CreateAsync(PetDTO petDTO)
        {
            var existingLocation = await _locationService.GetByNameAsync(petDTO.LocationDTO.LocationName);
            var existingCategory = await _categoryService.GetByNameAsync(petDTO.CategoryDTO.CategoryName);
            var existingBreed = await _breedService.GetByNameAsync(petDTO.BreedDTO.BreedName);

            if (existingLocation == null || existingCategory == null || existingBreed == null) return false;

            var newPet = new Pet
            {
                PetName = petDTO.PetName,
                CategoryId = existingCategory.Id,
                BreedId = existingBreed.Id,
                LocationId = existingLocation.Id,
                Age = petDTO.Age,
                Description = petDTO.Description,
                ImageUrl = petDTO.ImageUrl,
            };

            await _petRepository.CreateAsync(newPet);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _petRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PetDTO>> GetAllAsync()
        {
            var pets = await _petRepository.GetAllAsync();
            return pets.Select(pet => new PetDTO
            {
                 Id = pet.Id,
                PetName = pet.PetName,
                CategoryDTO = new CategoryDTO
                {
                    Id = pet.Category.Id,
                    CategoryName = pet.Category.CategoryName
                },
                BreedDTO = new BreedDTO
                {
                    Id = pet.Breed.Id,
                    BreedName = pet.Breed.BreedName
                },
                LocationDTO = new LocationDTO
                {
                    Id = pet.Location.Id,
                    LocationName = pet.Location.LocationName
                },

                Age = pet.Age,
                Description = pet.Description,
                ImageUrl = pet.ImageUrl
            });

              
        }

        public async Task<PetDTO> GetByIdAsync(int id)
        {
            var existingPet = await _petRepository.GetByIdAsync(id);
            if (existingPet != null) return new PetDTO
            {
                Id = existingPet.Id,
                PetName = existingPet.PetName,
                CategoryDTO = new CategoryDTO
                {
                    Id = existingPet.Category.Id,
                    CategoryName = existingPet.Category.CategoryName
                },
                BreedDTO = new BreedDTO
                {
                    Id = existingPet.Breed.Id,
                    BreedName = existingPet.Breed.BreedName
                },
                LocationDTO = new LocationDTO
                {
                    Id = existingPet.Location.Id,
                    LocationName = existingPet.Location.LocationName
                },

                Age = existingPet.Age,
                Description = existingPet.Description,
                ImageUrl = existingPet.ImageUrl
            };

            return null;
      
        }

        public async Task<bool> UpdateAsync(PetDTO item)
        {
            var existingPet = await _petRepository.GetByIdAsync(item.Id);
            if (existingPet == null) return false;

            return await _petRepository.UpdateAsync(existingPet);
        }
    }
}
