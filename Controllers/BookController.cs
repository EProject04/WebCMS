using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminPage.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            string jsonData = System.IO.File.ReadAllText("myJson.json");
            var model = JsonConvert.DeserializeObject<List<Book>>(jsonData);
            ViewBag.Books = model;
            return View();
        }
    }
}