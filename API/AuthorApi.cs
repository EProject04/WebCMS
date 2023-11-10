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
            var response = adminHttp.GetHttpClient().GetAsync("api/authors/get-all-author").Result;
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
            var response = adminHttp.GetHttpClient().GetAsync("api/authors/get-author-by-id/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateAuthor(int id, MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PutAsync("api/authors/update-author/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteAuthor(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("api/authors/delete-author/" + id).Result;
            return response;
        }
    }
}
