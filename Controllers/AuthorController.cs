using AdminPage.API;
using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPage.Controllers
{
    public class AuthorController : Controller
    {
        private AuthorApi _authorApi;
        public AuthorController()
        {
            _authorApi = new AuthorApi();
        }
        public IActionResult Index()
        {
            HttpResponseMessage response = _authorApi.GetAuthor();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<List<AuthorDto>>(content);
                ViewBag.Authors = model;
                return View();
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Create()
        {
            ViewBag.valid = true;
            return View();
        }
        public IActionResult AddNew(AuthorViewModel model)
        {
            ViewBag.valid = true;
            JObject o = new JObject();
            o["AuthorName"] = model.AuthorName;
            HttpResponseMessage response = _authorApi.AddAuthor(o.ToString());
            if (response.IsSuccessStatusCode) {
                return RedirectToAction("create", "Author");
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Detail(int id)
        {
            HttpResponseMessage response = _authorApi.FindAuthor(id);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var author = JsonConvert.DeserializeObject<AuthorDto>(content);
                var viewModel = new AuthorViewModel();
                viewModel.Id = id;
                viewModel.AuthorName = author.AuthorName;
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Update(AuthorViewModel viewModel)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(viewModel.Id.ToString()), "Id");
            formData.Add(new StringContent(viewModel.AuthorName), "AuthorName");
            HttpResponseMessage reponse = _authorApi.UpdateAuthor(viewModel.Id, formData);
            if (reponse.IsSuccessStatusCode)
            {
                return RedirectToAction("detail", "Category", viewModel.Id);
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = _authorApi.DeleteAuthor(id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "Author");
            }
            else
            {
                return RedirectToAction("index","User");
            }
        }
    }
}
