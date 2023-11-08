using Newtonsoft.Json;

namespace AdminPage.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Category(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }
    }
}
