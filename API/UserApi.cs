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
            var response = adminHttp.GetHttpClient().GetAsync("api/users/get-all-user").Result;
            return response;
        }
        public HttpResponseMessage AddUser(string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PostAsync("api/users/create-user", content).Result;
            return response;
        }
        public HttpResponseMessage FindUser(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("api/users/get-user-by-id/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateUser(int id, string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PutAsync("api/users/update-user/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteUser(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("api/users/delete-user/" + id).Result;
            return response;
        }
        public HttpResponseMessage Login(string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PostAsync("api/users/login", content).Result;
            return response;
        }
        public HttpResponseMessage Logout()
        {
            var response = adminHttp.GetHttpClient().GetAsync("api/users/logout").Result;
            return response;
        }
    }
}
