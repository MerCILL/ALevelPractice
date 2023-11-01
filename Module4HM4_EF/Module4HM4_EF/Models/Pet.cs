namespace Module4HM4_EF.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public int CategoryId { get; set; }
        public required Category Category { get; set; }

        public int BreedId { get; set; }
        public required Breed Breed { get; set; }

        public int Age { get; set; }

        public int LocationId { get; set; } 
        public required Location Location { get; set; }

        public string ImageUrl { get; set; } = String.Empty;
        public required string Description { get; set; }


    }
}
