using Microsoft.AspNetCore.Mvc;
using Module4_HM4_EF2.DTOs;
using Module4_HM4_EF2.Services;
using Module4_HM4_EF2.Services.Abstractions;

namespace Module4_HM4_EF2.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existingPet = await _petService.GetByIdAsync(id);
            if (existingPet == null) return NotFound();

            var petToReturn = new
            {
                existingPet.Id,
                existingPet.PetName,
                CategoryName = existingPet.CategoryDTO.CategoryName,
                BreedName = existingPet.BreedDTO.BreedName,
                LocationName = existingPet.LocationDTO.LocationName,
                existingPet.Age,
                existingPet.Description,
                existingPet.ImageUrl
            };

            return Ok(petToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var existingPets = await _petService.GetAllAsync();

            var petsToReturn = existingPets.Select(pet =>
            new
            {
                pet.Id,
                pet.PetName,
                CategoryName = pet.CategoryDTO.CategoryName,
                BreedName = pet.BreedDTO.BreedName,
                LocationName = pet.LocationDTO.LocationName,
                pet.Age,
                pet.Description,
                pet.ImageUrl
            });

            return Ok(petsToReturn);          
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePetModel createPetModel)
        {
            var petDTO = new PetDTO
            {
                PetName = createPetModel.PetName,
                CategoryDTO = new CategoryDTO { CategoryName = createPetModel.PetCategory },
                BreedDTO = new BreedDTO { BreedName = createPetModel.PetBreed },
                LocationDTO = new LocationDTO { LocationName = createPetModel.PetLocation },
                Age = createPetModel.Age,
                ImageUrl = createPetModel.ImageUrl,
                Description = createPetModel.Description
            };

            var result = await _petService.CreateAsync(petDTO);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _petService.DeleteAsync(id);
            if (result == false) return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(CreatePetModel updatePetModel)
        {
            var petDTO = new PetDTO
            {
                PetName = updatePetModel.PetName,
                CategoryDTO = new CategoryDTO { CategoryName = updatePetModel.PetCategory },
                BreedDTO = new BreedDTO { BreedName = updatePetModel.PetBreed },
                LocationDTO = new LocationDTO { LocationName = updatePetModel.PetLocation },
                Age = updatePetModel.Age,
                ImageUrl = updatePetModel.ImageUrl,
                Description = updatePetModel.Description
            };

            var result = await _petService.UpdateAsync(petDTO);

            if (result == false) return NotFound();

            return Ok();
        }

    }
}
