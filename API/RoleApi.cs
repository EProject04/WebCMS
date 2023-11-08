using AdminPage.AdminHttp;
using System.Text;

namespace AdminPage.API
{
    public class RoleApi
    {
        AdminApiHttp adminHttp;
        public RoleApi()
        {
            adminHttp = AdminApiHttp.Instance();
        }
        public HttpResponseMessage GetRole()
        {
            var response = adminHttp.GetHttpClient().GetAsync("Roles").Result;
            return response;
        }
        public HttpResponseMessage AddRole(string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PostAsync("Roles", content).Result;
            return response;
        }
        public HttpResponseMessage FindRole(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("Roles/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateRole(int id, string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PutAsync("Roles/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteRoles(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("Roles/" + id).Result;
            return response;
        }
    }
}
