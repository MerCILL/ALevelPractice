namespace Module4_HM4_EF2.DbData.Models
{
    public class Location
    {
        public int Id { get; set; }
        public required string LocationName { get; set; }
        public ICollection<Pet>? Pets { get; set; }
    }
}
