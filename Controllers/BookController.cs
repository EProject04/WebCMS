using AdminPage.API;
using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPage.Controllers
{
    public class BookController : Controller
    {
        private BookApi _bookApi;
        private CategoryApi _categoryApi;
        private AuthorApi _authorApi;
        public BookController()
        {
            _bookApi = new BookApi();
            _categoryApi = new CategoryApi();
            _authorApi = new AuthorApi();
        }
        public IActionResult Index()
        {
            HttpResponseMessage response = _bookApi.GetBook();
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var books = JsonConvert.DeserializeObject<List<BookDto>>(content);
                ViewBag.Books = books;
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }
        public IActionResult Create()
        {
            ViewBag.valid = true;
            var viewModel = new BookCreateViewModel();
            HttpResponseMessage categoryResponse = _categoryApi.GetCategory();
            if (categoryResponse.IsSuccessStatusCode)
            {
                var content = categoryResponse.Content.ReadAsStringAsync().Result;
                var categories = JsonConvert.DeserializeObject<List<CategoryDto>>(content);
                viewModel.Categories = categories;
            }
            else
            {
                return RedirectToAction("index", "Book");
            }
            HttpResponseMessage authorResponse = _authorApi.GetAuthor();
            if (authorResponse.IsSuccessStatusCode)
            {
                var content = authorResponse.Content.ReadAsStringAsync().Result;
                var authors = JsonConvert.DeserializeObject<List<AuthorDto>>(content);
                viewModel.Authors = authors;
            }
            else
            {
                return RedirectToAction("index", "Book");
            }
            //ViewBag.valid = true;
            //var categories = new List<CategoryDto> {
            //    new CategoryDto(1,"horror"),
            //    new CategoryDto(2,"romance"),
            //    new CategoryDto(3,"slice of life"),
            //};
            //var authors = new List<AuthorDto> {
            //    new AuthorDto(1,"Shinkai Makoto"),
            //    new AuthorDto(2,"A Nguyen"),
            //    new AuthorDto(3,"B Nguyen"),
            //};
            //BookViewModel viewModel = new BookViewModel();
            //viewModel.Authors = authors;
            //viewModel.Categories = categories;
            //viewModel.Status = null;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddNew(BookViewModel viewModel)
        {
            ViewBag.valid = true;
            if (false)
            {
                ViewBag.valid = false;
                return View("Create");
            }
            string authorIdString = String.Join(",", viewModel.AuthorId);
            string categoryIdString = String.Join(",", viewModel.CategoryId);
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(viewModel.Image.OpenReadStream()), "File", viewModel.Image.FileName);
            formData.Add(new StringContent(viewModel.Title), "Title");
            formData.Add(new StringContent(viewModel.Content), "Content");
            formData.Add(new StringContent(viewModel.Status.ToString()), "Status");
            formData.Add(new StringContent(authorIdString), "AuthorId");
            formData.Add(new StringContent(categoryIdString), "CategoryId");
            HttpResponseMessage response = _bookApi.AddBook(formData);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("create", "Book");
            }
            else
            {
                return RedirectToAction("create", "Book");
            }
        }
        public IActionResult Detail(int id)
        {
            ViewBag.valid = true;
            HttpResponseMessage response = _bookApi.FindBook(id);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var book = JsonConvert.DeserializeObject<BookDto>(content);
                var viewModel = new BookViewModel();
                viewModel.Id = id;
                viewModel.Title = book.Title;
                viewModel.Description = book.Description;
                viewModel.Content = book.Content;
                viewModel.ImagePath = book.ImagePath;
                viewModel.Status = book.Status;
                viewModel.Authors = book.BookFollows;
                viewModel.AuthorId = book.BookFollows.Select(x => x.Id).ToArray();
                viewModel.Categories = book.CategoriesBook;
                viewModel.CategoryId = book.CategoriesBook.Select(x => x.Id).ToArray();
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("index", "Book");
            }
        }
        public IActionResult Update(BookViewModel viewModel)
        {
            string authorIdString = String.Join(",", viewModel.AuthorId);
            string categoryIdString = String.Join(",", viewModel.CategoryId);
            var formData = new MultipartFormDataContent();
            formData.Add(new StreamContent(viewModel.Image.OpenReadStream()), "File", viewModel.Image.FileName);
            formData.Add(new StringContent(viewModel.Title), "Title");
            formData.Add(new StringContent(viewModel.Content), "Content");
            formData.Add(new StringContent(viewModel.Status.ToString()), "Status");
            formData.Add(new StringContent(authorIdString), "AuthorId");
            formData.Add(new StringContent(categoryIdString), "CategoryId");
            HttpResponseMessage response = _bookApi.UpdateBook(viewModel.Id, formData);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("detail", "Book", viewModel.Id);
            }
            else
            {
                return RedirectToAction("detail", "Book", viewModel.Id);
            }
        }
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = _bookApi.DeleteBook(id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "Book");
            }
            else
            {
                return RedirectToAction("index", "Book");
            }
        }
    }
}