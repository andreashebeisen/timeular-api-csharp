using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using timeular_api_csharp.Models.Tracking;

namespace timeular_api_csharp.Infrastructure
{
    public class TrackingManager
    {
        public async Task<CurrentTrackingResponse> GetCurrentTracking(string token)
        {
            var response = await HttpClientHelper.Get("/tracking", token: token);
            return JsonConvert.DeserializeObject<CurrentTrackingResponse>(response);
        }

        public async Task<StartedTrackingResponse> StartTracking(string activityId, StartTrackingRequest request,  string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Post($"/tracking/{activityId}/start", jsonObject, token);
            return JsonConvert.DeserializeObject<StartedTrackingResponse>(response);
        }

        public async Task<EditTrackingResponse> EditTracking(string activityId, EditTrackingRequest request, string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Patch($"/tracking/{activityId}", jsonObject, token);
            return JsonConvert.DeserializeObject<EditTrackingResponse>(response);
        }

        public async Task<StoppedTrackingResponse> StopTracking(string activityId, StopTrackingRequest request, string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Post($"/tracking/{activityId}/stop", jsonObject, token);
            return JsonConvert.DeserializeObject<StoppedTrackingResponse>(response);
        }
    }
}
