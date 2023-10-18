using Newtonsoft.Json;

namespace AdminPage.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly ReleaseDate { get; set; }

        public Book(int id, string title, string description, string content, string imagePath, bool status, DateOnly releaseDate) {
            Id = id;
            Title = title;
            Description = description;
            Content = content;
            ImagePath = imagePath;
            Status = status;
            ReleaseDate = releaseDate;
        }
    }
}
