namespace MVC.Models
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureFileName { get; set; }

        public string PictureUrl
        {
            get
            {
                return $"http://localhost:80{PictureFileName}";
            }
        }
    }
}
