using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Json_From_Web
{
    public class HostDetails
    {
        private UriBuilder _uriBuilder;

        public HostDetails(string scheme, string host, string path)
        {
            _uriBuilder = new UriBuilder();
            _uriBuilder.Scheme = scheme;
            _uriBuilder.Host = host;
            _uriBuilder.Path = path;
        }

        protected internal UriBuilder GetUriBuilder()
        {
            return _uriBuilder;
        }
    }

    public static class JsonHost
    {
        public static string GetJson(HostDetails host, string query)
        {
            var uriBuilder = host.GetUriBuilder();
            var url = UrlBuilder(uriBuilder, query);

            return GetJsonFromHost(url);
        }

        public static string GetJson(string url)
        {
            return GetJsonFromHost(url);
        }

        private static string UrlBuilder(UriBuilder uriBuilder, string query)
        {
            uriBuilder.Query = query;

            return uriBuilder.ToString();
        }

        private static string GetJsonFromHost(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    
}
}
