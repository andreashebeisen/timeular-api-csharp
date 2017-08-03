using System.Threading.Tasks;
using Newtonsoft.Json;
using timeular_api_csharp.Models.Integrations;

namespace timeular_api_csharp.Infrastructure
{
    public class IntegrationManager
    {
        public async Task<IntegrationsResponse> GetIntegrations(string token)
        {
            var response = await HttpClientHelper.Get("/integrations", token: token);
            return JsonConvert.DeserializeObject<IntegrationsResponse>(response);
        }
    }
}
