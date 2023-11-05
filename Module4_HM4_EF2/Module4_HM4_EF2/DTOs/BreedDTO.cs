using Module4_HM4_EF2.DbData.Models;

namespace Module4_HM4_EF2.DTOs
{
    public class BreedDTO
    {
        public int Id { get; set; }
        public string? BreedName { get; set; }

        public CategoryDTO? CategoryDTO { get; set; }

    }
}
