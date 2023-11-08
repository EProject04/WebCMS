using AdminPage.AdminHttp;
using System.Text;

namespace AdminPage.API
{
    public class AuthorApi
    {
        AdminApiHttp adminHttp;
        public AuthorApi()
        {
            adminHttp = AdminApiHttp.Instance();
        }
        public HttpResponseMessage GetAuthor()
        {
            var response = adminHttp.GetHttpClient().GetAsync("Authors").Result;
            return response;
        }
        public HttpResponseMessage AddAuthor(string jsonContent)
        {
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = adminHttp.GetHttpClient().PostAsync("Authors", content).Result;
            return response;
        }
        public HttpResponseMessage FindAuthor(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("Authors/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateAuthor(int id, MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PutAsync("Authors/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteAuthor(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("Authors/" + id).Result;
            return response;
        }
    }
}
