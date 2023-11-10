namespace AdminPage.Models
{
    public class CategoryBook
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BookId { get; set; }
        public string CategoryName { get; set; }
    }
}
