namespace Module4_HM4_EF2.DbData.Models
{ 
    public class PetFood
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;

        public int FoodId { get; set; }
        public Food Food { get; set; } = null!;
    }
}
