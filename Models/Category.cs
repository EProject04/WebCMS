using Newtonsoft.Json;

namespace AdminPage.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly CreateDate { get; set; }

        public Category(int id, string categoryName, string description, string imagePath, DateOnly createDate)
        {
            Id = id;
            CategoryName = categoryName;
            Description = description;
            ImagePath = imagePath;
            CreateDate = createDate;
        }
    }
}
