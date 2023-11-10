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
            var response = adminHttp.GetHttpClient().GetAsync("api/books/get-all-book").Result;
            return response;
        }
        public HttpResponseMessage AddBook(MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PostAsync("api/books/create-book", content).Result;
            return response;
        }
        public HttpResponseMessage FindBook(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("api/books/get-book-by-id/" + id).Result;
            return response;
        }
        public HttpResponseMessage UpdateBook(int id, MultipartFormDataContent content)
        {
            var response = adminHttp.GetHttpClient().PutAsync("api/books/update-book/" + id, content).Result;
            return response;
        }
        public HttpResponseMessage DeleteBook(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("api/books/delete-book/" + id).Result;
            return response;
        }
    }
}
