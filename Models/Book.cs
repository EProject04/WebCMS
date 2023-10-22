using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

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
        public static string imageFileName(string title)
        {
            string pattern = "[/@:*?\"<>|]";
            title = Regex.Replace(title, pattern, string.Empty);
            title = title.Replace("\\", string.Empty);
            title = title.Replace(" ","-") + ".jpg";
            return title;
        }
        public static string contentFileName(string title)
        {
            string pattern = "[/@:*?\"<>|]";
            title = Regex.Replace(title, pattern, string.Empty);
            title = title.Replace("\\", string.Empty);
            title = title.Replace(" ", "-") + ".txt";
            return title;
        }
        public string toJson()
        {
            JObject bookJson = new JObject();
            bookJson["title"] = Title;
            bookJson["description"] = Description;
            bookJson["content"] = Content;
            bookJson["imagePath"] = ImagePath;
            bookJson["status"] = Status;
            bookJson["releaseDate"] = ReleaseDate.ToString();
            return bookJson.ToString();
        }
    }
}
