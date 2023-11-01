namespace Module4HM4_EF.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }

        public int BreedId { get; set; }
        public required ICollection<Breed> Breeds { get; set; }

        public int PetId { get; set; }
        public required ICollection<Pet> Pets { get; set; }
    }
}
