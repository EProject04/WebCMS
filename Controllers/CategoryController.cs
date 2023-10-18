using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminPage.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            string jsonData = System.IO.File.ReadAllText("categoryJson.json");
            var model = JsonConvert.DeserializeObject<List<Category>>(jsonData);
            ViewBag.Categories = model;
            return View();
        }
    }
}
