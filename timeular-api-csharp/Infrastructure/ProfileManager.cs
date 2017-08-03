using System.Threading.Tasks;
using Newtonsoft.Json;
using timeular_api_csharp.Models.Profile;

namespace timeular_api_csharp.Infrastructure
{
    public class ProfileManager
    {
        public async Task<ProfileResponse> GetProfile(string token)
        {
            var response = await HttpClientHelper.Get("/user/profile", token: token);
            return JsonConvert.DeserializeObject<ProfileResponse>(response);
        }
    }
}
