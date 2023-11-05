namespace Module4_HM4_EF2.DbData.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }

        public ICollection<Breed>? Breeds { get; set; }
        public ICollection<Pet>? Pets { get; set; }

    }
}
