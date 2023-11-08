namespace Module4HM4_EF.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public required string BreedName { get; set; }

        public int CategoryId { get; set; }
        public required Category Category { get; set; }

        public int PetId { get; set; }
        public required ICollection<Pet> Pets { get; set;}
    }
}
