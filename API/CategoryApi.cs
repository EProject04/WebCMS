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
            var response = adminHttp.GetHttpClient().GetAsync("Categories").Result;
            return response;
        }
        public HttpResponseMessage AddCategory(MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PostAsync("Categories", content).Result;
            return response;
        }
        public HttpResponseMessage FindCategory(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("Categories/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateCategory(int id, MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PutAsync("Categories/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteCategory(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("Categories/" + id).Result;
            return response;
        }
    }
}
