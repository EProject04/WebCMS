using AdminPage.AdminHttp;

namespace AdminPage.API
{
    public class CommentApi
    {
        AdminApiHttp adminHttp;
        public CommentApi()
        {
            adminHttp = AdminApiHttp.Instance();
        }
        public HttpResponseMessage GetComment()
        {
            var response = adminHttp.GetHttpClient().GetAsync("comments").Result;
            return response;
        }
        public HttpResponseMessage FindComment(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("comments/" + id).Result;
            return response;
        }
        public HttpResponseMessage DeleteComment(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("comments/" + id).Result;
            return response;
        }
    }
}