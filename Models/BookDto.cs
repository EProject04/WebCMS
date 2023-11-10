using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace AdminPage.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public bool? Status { get; set; }
        //[JsonConverter(typeof(DateOnlyJsonConverter))]
        //public DateOnly ReleaseDate { get; set; }
        public List<BookFollow> BookFollows { get; set; }
        public List<CategoryBook> CategoriesBook { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
