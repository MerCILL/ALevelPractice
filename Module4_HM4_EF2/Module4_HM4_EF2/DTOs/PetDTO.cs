using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DTOs
{
    public class PetDTO
    {
        public int Id { get; set; } 
        public string? PetName { get; set; }

        public LocationDTO? LocationDTO { get; set; }
        public CategoryDTO? CategoryDTO { get; set; }
        public BreedDTO? BreedDTO { get; set; }

        //Food
        //Insurance

        public int? Age { get; set; }
        public string? ImageUrl { get; set; } 
        public string? Description { get; set; }

    }
}
