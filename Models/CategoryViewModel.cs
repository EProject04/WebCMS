namespace AdminPage.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public string ImagePath { get; set; }
    }
}