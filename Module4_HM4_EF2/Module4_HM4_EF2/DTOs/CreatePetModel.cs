namespace Module4_HM4_EF2.DTOs
{
    public class CreatePetModel
    {
        public string PetName { get; set; }
        public string PetCategory { get; set; }
        public string PetLocation { get; set; }

        public string PetBreed { get; set; }
        public int? Age { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
