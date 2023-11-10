using AdminPage.AdminHttp;
using System.Text;

namespace AdminPage.API
{
    public class CategoryApi
    {
        AdminApiHttp adminHttp;
        public CategoryApi()
        {
            adminHttp = AdminApiHttp.Instance();
        }
        public HttpResponseMessage GetCategory()
        {
            var response = adminHttp.GetHttpClient().GetAsync("api/Categories").Result;
            return response;
        }
        public HttpResponseMessage AddCategory(MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PostAsync("api/Categories", content).Result;
            return response;
        }
        public HttpResponseMessage FindCategory(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("api/Categories/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateCategory(int id, MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PutAsync("api/Categories/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteCategory(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("api/Categories/" + id).Result;
            return response;
        }
    }
}
