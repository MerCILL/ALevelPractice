namespace Module4_HM4_EF2.DbData.Models
{
    public enum FoodType
    {
        Feed,
        Beef
    }
    public class Food
    {
        public int Id { get; set; }
        public required string FoodName { get; set; }
        public FoodType FoodType { get; set; }

        public ICollection<PetFood>? PetFoods { get; set; }
    }
}
