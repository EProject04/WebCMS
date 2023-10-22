using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPage.Controllers
{
    public class BookController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public BookController(IWebHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            string jsonData = System.IO.File.ReadAllText("myJson.json");
            var model = JsonConvert.DeserializeObject<List<Book>>(jsonData);
            ViewBag.Books = model;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.valid = true;
            return View();
        }
        public async Task<IActionResult> AddNew(string title, string description, IFormFile image, IFormFile content, bool status, string releaseDate)
        {
            ViewBag.valid = true;
            Console.WriteLine(releaseDate);

            if (image == null || title == "" || description == "" || content == null || releaseDate == "")
            {
                ViewBag.valid = false;
                return View("Create");
            }
            string[] date = releaseDate.Split('-');
            Book book = new Book(0, title, description, "", "", status, new DateOnly(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])));
            string imgFileName = Book.imageFileName(title);
            string contentFileName = Book.contentFileName(title);
            string imgFilePath = Path.Combine(_env.WebRootPath, "images", imgFileName);
            using (var fileStream = new FileStream(imgFilePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            string contentFilePath = Path.Combine(_env.WebRootPath, "content", contentFileName);
            using (var fileStream = new FileStream(contentFilePath, FileMode.Create))
            {
                await content.CopyToAsync(fileStream);
            }
            Console.WriteLine(contentFilePath);
            Console.WriteLine(imgFileName);
            return View("Create");
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
        public IActionResult Update()
        {
            return View("Detail");
        }
        public IActionResult Delete(int id)
        {
            string jsonData = System.IO.File.ReadAllText("myJson.json");
            var model = JsonConvert.DeserializeObject<List<Book>>(jsonData);
            ViewBag.Books = model;
            return View("Index");
        }
    }
}