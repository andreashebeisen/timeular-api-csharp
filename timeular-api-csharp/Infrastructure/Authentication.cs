using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using timeular_api_csharp.Models.Authentication;

namespace timeular_api_csharp.Infrastructure
{
    public class Authentication
    {
        public async Task<SignInResponse> GetAccessToken(SignInRequest request)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Post("/developer/sign-in", jsonObject );
            return JsonConvert.DeserializeObject<SignInResponse>(response);

        }

        public async Task<ApiAccessResponse> GetApiKey(string token)
        {
            var response = await HttpClientHelper.Get("/developer/api-access", token: token);
            return JsonConvert.DeserializeObject<ApiAccessResponse>(response);
        }

        public async Task<FullApiAccessResponse> GetNewApiSecret(string token)
        {
            var response = await HttpClientHelper.Post("/developer/api-access", token: token);
            return JsonConvert.DeserializeObject<FullApiAccessResponse>(response);
        }
    }
}
