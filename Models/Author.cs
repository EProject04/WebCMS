namespace AdminPage.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public Author(int id, string authorName)
        {
            Id = id;
            AuthorName = authorName;
        }
    }
}
