using AdminPage.API;
using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace AdminPage.Controllers
{
    public class UserController : Controller
    {
        private UserApi _userApi;
        public UserController()
        {
            _userApi = new UserApi();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            HttpResponseMessage response = _userApi.FindUser(id);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<User>(content);
                var viewModel = new UserViewModel();
                viewModel.Id = id;
                viewModel.UserName = user.UserName;
                viewModel.Password = user.Password;
                viewModel.RoleName = user.RoleName;
                viewModel.CreateDate = user.CreateDate;
                viewModel.LastModifiedDate = user.LastModifiedDate;
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Update(int id, UserViewModel viewModel)
        {
            JObject o = new JObject();
            o["Id"] = id;
            o["UserName"] = viewModel.UserName;
            o["Password"] = viewModel.Password;
            o["Email"] = viewModel.Email;
            HttpResponseMessage response = _userApi.UpdateUser(viewModel.Id, o.ToString());
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("detail", "User", viewModel.Id);
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login(string username, string password)
        {
            JObject o = new JObject();
            o["username"] = username;
            o["password"] = password;
            HttpResponseMessage response = _userApi.Login(o.ToString());
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "Home");
            }
            else
            {
                return View("index");
            }
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
