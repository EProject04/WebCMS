namespace AdminPage.Models
{
    public class BookCreateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        public bool? Status { get; set; }
        public List<AuthorDto> Authors { get; set; }
        public int[] AuthorId { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public int[] CategoryId { get; set; }
    }
}
