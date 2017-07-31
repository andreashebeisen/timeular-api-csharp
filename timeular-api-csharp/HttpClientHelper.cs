using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace timeular_api_csharp
{
    public static class HttpClientHelper
    {
        private const string BaseUrl = "https://api.timeular.com/api/v1";
        
        #region Private Methods
        public static async Task<string> Post(string ressource, string request= null,  string token = null)
        {
            using (var client = new HttpClient())
            {
                var url = $"{BaseUrl}{ressource}";

                if (request == null) request = string.Empty;

                var content = new StringContent(
                    request,  // content 
                    Encoding.UTF8, //encoding
                    "application/json" // mediaType
                );
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                }

                var result = await client.PostAsync(url, content);
                return await result.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> Get(string ressource, string querystring = null, string token = null)
        {
            using (var client = new HttpClient())
            {
                var url = $"{BaseUrl}{ressource}";

                if (!string.IsNullOrWhiteSpace(querystring))
                {
                    url = $"{url}?{querystring.Trim()}";
                }

                var uri = new Uri(url);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                }

                var result = await client.GetAsync(uri);
                return await result.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> Patch(string ressource, string request = null, string token = null)
        {
            using (var client = new HttpClient())
            {
                var url = $"{BaseUrl}{ressource}";

                if (request == null) request = string.Empty;

                var content = new StringContent(
                    request,  // content 
                    Encoding.UTF8, //encoding
                    "application/json" // mediaType
                );
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                }

                var uri = new Uri(url);
                var method = new HttpMethod("PATCH");

                var message = new HttpRequestMessage(method, uri)
                {
                    Content = content
                };

                var result = await client.SendAsync(message);
                return await result.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> Delete(string ressource, string request = null, string token = null)
        {
            using (var client = new HttpClient())
            {
                var url = $"{BaseUrl}{ressource}";

                if (request == null) request = string.Empty;

                var content = new StringContent(
                    request,  // content 
                    Encoding.UTF8, //encoding
                    "application/json" // mediaType
                );
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Trim());
                }

                var uri = new Uri(url);
                var method = new HttpMethod("DELETE");

                var message = new HttpRequestMessage(method, uri)
                {
                    Content = content
                };

                var result = await client.SendAsync(message);
                return await result.Content.ReadAsStringAsync();
            }
        }
        #endregion

    }
}
