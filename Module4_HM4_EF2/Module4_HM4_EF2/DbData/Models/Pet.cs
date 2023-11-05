namespace Module4_HM4_EF2.DbData.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public required string PetName { get; set; }

        public required int LocationId { get; set; }
        public Location? Location { get; set; }

        public required int CategoryId { get; set; }
        public Category? Category { get; set; }

        public required int BreedId { get; set; }
        public Breed? Breed { get; set; }

        public int? Age { get; set; }
        public string? ImageUrl { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;

        public int? PetInsuranceId { get; set; }
        public PetInsurance? PetInsurance { get; set; }

        public ICollection<PetFood>? PetFoods { get; set; }

    }
}
