using AdminPage.AdminHttp;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace AdminPage.API
{
    public class BookApi
    {
        AdminApiHttp adminHttp;
        public BookApi()
        {
            adminHttp = AdminApiHttp.Instance();
        }
        public HttpResponseMessage GetBook()
        {
            var response = adminHttp.GetHttpClient().GetAsync("Books").Result;
            return response;
        }
        public HttpResponseMessage AddBook(MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PostAsync("Books", content).Result;
            return response;
        }
        public HttpResponseMessage FindBook(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("Books/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateBook(int id, MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PutAsync("Books/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteBook(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("Books/" + id).Result;
            return response;
        }
    }
}
