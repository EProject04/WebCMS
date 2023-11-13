using AdminPage.API;
using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace AdminPage.Controllers
{
    public class UserController : Controller
    {
        private UserApi _userApi;
        private RoleApi _roleApi;
        public UserController()
        {
            _userApi = new UserApi();
            _roleApi = new RoleApi();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var viewModel = new UserCreateViewModel();
            List<RoleDto> roles;
            HttpResponseMessage roleResponse = _roleApi.GetRole();
            if (roleResponse.IsSuccessStatusCode)
            {
                var content = roleResponse.Content.ReadAsStringAsync().Result;
                roles = JsonConvert.DeserializeObject<List<RoleDto>>(content);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            HttpResponseMessage userResponse = _userApi.FindUser(id);
            if (userResponse.IsSuccessStatusCode)
            {
                var content = userResponse.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<UserDto>(content);
                
                viewModel.Id = id;
                viewModel.UserName = user.UserName;
                viewModel.Password = user.Password;
                viewModel.Email = user.Email;
                viewModel.RoleId = roles.Where(role => role.RoleName == user.RoleName).Select(role => role.Id).FirstOrDefault();
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("index", "User");
            }
        }
        public IActionResult Update(int id, UserCreateViewModel viewModel)
        {
            JObject o = new JObject();
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
                return RedirectToAction("detail", "User", viewModel.Id);
            }
        }
        public IActionResult Create()
        {
            var viewModel = new UserCreateViewModel();
            HttpResponseMessage roleResponse = _roleApi.GetRole();
            if (roleResponse.IsSuccessStatusCode)
            {
                var content = roleResponse.Content.ReadAsStringAsync().Result;
                var roles = JsonConvert.DeserializeObject<List<RoleDto>>(content);
                viewModel.Roles = roles;
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            return View(viewModel);
        }
        public ActionResult AddNew(UserCreateViewModel viewModel)
        {
            JObject o = new JObject();
            o["UserName"] = viewModel.UserName;
            o["Password"] = viewModel.Password;
            o["Email"] = viewModel.Email;
            o["RoleId"] = viewModel.RoleId;
            HttpResponseMessage response = _userApi.AddUser(o.ToString());
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("create", "User");
            }
            else
            {
                return RedirectToAction("create", "User");
            }
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
