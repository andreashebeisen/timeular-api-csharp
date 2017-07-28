using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using timeular_api_csharp.Models.Authentication;

namespace timeular_api_csharp.Infrastructure
{
    public class Authentication
    {
        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            using (var client = new HttpClient())
            {
                var url = "https://api.timeular.com/api/v1/" + "developer/sign-in";

                var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                var content = new StringContent(
                    jsonObject,  // content 
                    Encoding.UTF8, //encoding
                    "application/json" // mediaType
                );
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = await client.PostAsync(url, content);


                return JsonConvert.DeserializeObject<SignInResponse>(await result.Content.ReadAsStringAsync());


            }
        }
    }
}
