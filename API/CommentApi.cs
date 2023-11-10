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
            var response = adminHttp.GetHttpClient().GetAsync("comments/get-all-comment").Result;
            return response;
        }
        public HttpResponseMessage FindComment(int id)
        {
            var response = adminHttp.GetHttpClient().GetAsync("comments/get-comment-by-id/" + id).Result;
            return response;
        }
        public HttpResponseMessage DeleteComment(int id)
        {
            var response = adminHttp.GetHttpClient().DeleteAsync("comments/delete-comment/" + id).Result;
            return response;
        }
    }
}