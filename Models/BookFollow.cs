namespace AdminPage.Models
{
    public class BookFollow
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public string AuthorName { get; set; }
    }
}
