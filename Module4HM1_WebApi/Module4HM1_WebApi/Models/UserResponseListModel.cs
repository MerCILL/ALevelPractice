namespace Module4HM1_WebApi.Models
{
    public class UserResponseListModel
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public List<User>? Data { get; set; }
    }
}
