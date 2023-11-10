namespace AdminPage.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public AuthorDto(int id, string authorName)
        {
            Id = id;
            AuthorName = authorName;
        }
    }
}
