namespace Module4HM4_EF.Models
{
    public class Location
    {
        public int Id { get; set; }
        public required string LocationName { get; set; }

        public int PetId { get; set; }
        public required ICollection<Pet> Pets { get; set; }
    }
}
