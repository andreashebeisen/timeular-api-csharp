using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using timeular_api_csharp.Models;
using timeular_api_csharp.Models.Tracking.Activities;

namespace timeular_api_csharp.Infrastructure
{
    public class ActivityManager
    {
        public async Task<ActivitiesConfigurationResponse> GetActivities(string token)
        {
            var response = await HttpClientHelper.Get("/activities", token: token);
            return JsonConvert.DeserializeObject<ActivitiesConfigurationResponse>(response);
        }

        public async Task<ActivityConfigurationResponse> CreateActivity(ActivityCreationRequest request, string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Post("/activities", jsonObject, token);
            return JsonConvert.DeserializeObject<ActivityConfigurationResponse>(response);
        }

        public async Task<ActivityConfigurationResponse> EditActivity(string activityId, ActivityEditionRequest request, string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Patch($"/activities/{activityId}", jsonObject, token);
            return JsonConvert.DeserializeObject<ActivityConfigurationResponse>(response);
        }

        public async Task<SuccessWithIgnoredErrorsResponse> DeleteActivity(string activityId, string token)
        {
            var response = await HttpClientHelper.Delete($"/activities/{activityId}", token: token);
            return JsonConvert.DeserializeObject<SuccessWithIgnoredErrorsResponse>(response);
        }

        public async Task<ActivityConfigurationResponse> AssignActivity(string activityId, int deviceSide, string token)
        {
            var response = await HttpClientHelper.Post($"/activities/{activityId}/device-side/{deviceSide}", token: token);
            return JsonConvert.DeserializeObject<ActivityConfigurationResponse>(response);
        }

        public async Task<SuccessWithIgnoredErrorsResponse> UnassignActivity(string activityId, int deviceSide, string token)
        {
            var response = await HttpClientHelper.Delete($"/activities/{activityId}/device-side/{deviceSide}", token: token);
            return JsonConvert.DeserializeObject<SuccessWithIgnoredErrorsResponse>(response);
        }

        public async Task<TagsAndMentionsResponse> GetActivityTagsAndMentions(string activityId, string token)
        {
            var response = await HttpClientHelper.Get($"/activities/{activityId}/tags-and-mentions", token: token);
            return JsonConvert.DeserializeObject<TagsAndMentionsResponse>(response);
        }

        public async Task<ArchivedActivitiesResponse> GetArchivedActivities(string token)
        {
            var response = await HttpClientHelper.Get($"/archived-activities", token: token);
            return JsonConvert.DeserializeObject<ArchivedActivitiesResponse>(response);
        }
    }
}
