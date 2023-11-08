using AdminPage.AdminHttp;
using System.Text;

namespace AdminPage.API
{
    public class UserApi
    {
        AdminApiHttp adminHttp;
        public UserApi()
        {
            adminHttp = AdminApiHttp.Instance();
        }
        public HttpResponseMessage GetUser()
        {
            var response = adminHttp.GetHttpClient().GetAsync("Users").Result;
            return response;
        }
        public HttpResponseMessage AddUser(string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PostAsync("Users", content).Result;
            return response;
        }
        public HttpResponseMessage FindUser(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("Users/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateUser(int id, string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PutAsync("Users/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteUser(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("Users/" + id).Result;
            return response;
        }
        public HttpResponseMessage RegisterUser(string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PostAsync("Users/register", content).Result;
            return response;
        }
        public HttpResponseMessage Login(string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PostAsync("Users/login", content).Result;
            return response;
        }
        public HttpResponseMessage Logout()
        {
            var response = adminHttp.GetHttpClient().GetAsync("Users/logout").Result;
            return response;
        }
    }
}
