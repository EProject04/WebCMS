using AdminPage.API;
using AdminPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPage.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryApi _categoryApi;
        public CategoryController(IWebHostEnvironment env) {
            _categoryApi = new CategoryApi();
        }
        public IActionResult Index()
        {
            HttpResponseMessage response = _categoryApi.GetCategory();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var Categories = JsonConvert.DeserializeObject<List<Category>>(content);
                ViewBag.Categories = Categories;
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
        public IActionResult AddNew(CategoryViewModel model)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(model.Image.OpenReadStream()), "File", model.Image.FileName);
            formData.Add(new StringContent(model.CategoryName),"CategoryName");
            formData.Add(new StringContent(model.Description), "Description");
            HttpResponseMessage response = _categoryApi.AddCategory(formData);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("create", "Category");
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Detail(int id)
        {
            HttpResponseMessage response = _categoryApi.FindCategory(id);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var category = JsonConvert.DeserializeObject<Category>(content);
                var viewModel = new CategoryViewModel();
                viewModel.Id = id;
                viewModel.CategoryName = category.CategoryName;
                viewModel.Description = category.Description;
                viewModel.ImagePath = category.ImagePath;
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Update(CategoryViewModel viewModel)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(viewModel.Image.OpenReadStream()), "File", viewModel.Image.FileName);
            formData.Add(new StringContent(viewModel.CategoryName), "CategoryName");
            formData.Add(new StringContent(viewModel.Description), "Description");
            HttpResponseMessage reponse = _categoryApi.UpdateCategory(viewModel.Id, formData);
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
            HttpResponseMessage response = _categoryApi.DeleteCategory(id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "Category");
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
    }
}
