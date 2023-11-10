using System.Net;

namespace AdminPage.AdminHttp
{
    public class AdminApiHttp
    {
        HttpClient client;
        private AdminApiHttp() {
            CookieContainer cookieContainer = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookieContainer;
            client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://aptechlearningproject.site/");
        }
        private static AdminApiHttp _instance;
        private static readonly object _instanceLock = new object();
        public static AdminApiHttp Instance()
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new AdminApiHttp();
                    }
                }
                _instance = new AdminApiHttp();
            }
            return _instance;
        }

        public HttpClient GetHttpClient()
        {
            return client;
        }

    }
}
