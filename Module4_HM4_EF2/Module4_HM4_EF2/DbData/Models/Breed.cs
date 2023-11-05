namespace Module4_HM4_EF2.DbData.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public required string BreedName { get; set; }

        public int CategoryId { get; set; }
        public required Category Category { get; set; }

        public ICollection<Pet>? Pets { get; set; }
    }
}
