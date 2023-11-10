using AdminPage.API;
using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminPage.Controllers
{
    public class CommentController : Controller
    {
        private CommentApi _commentApi;
        public CommentController()
        {
            _commentApi = new CommentApi();
        }
        public IActionResult Index()
        {
            HttpResponseMessage response = _commentApi.GetComment();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var comments = JsonConvert.DeserializeObject<List<CommentDto>>(content);
                ViewBag.Comments = comments;
                return View();
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
    }
}
