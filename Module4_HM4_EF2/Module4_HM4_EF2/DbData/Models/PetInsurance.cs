namespace Module4_HM4_EF2.DbData.Models
{
    public class PetInsurance
    {
        public int Id { get; set; }

        public DateOnly StartInsuranceDate { get; set; }
        public DateOnly EndInsuranceDate { get; set; }

        public required int PetId { get; set; }
        public Pet? Pet { get; set; }
    }
}
