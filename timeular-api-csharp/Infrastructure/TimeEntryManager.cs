using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using timeular_api_csharp.Models;
using timeular_api_csharp.Models.Tracking.Entries;

namespace timeular_api_csharp.Infrastructure
{
    public class TimeEntryManager
    {
        public async Task<TimeEntriesResponse> FindTimeEntries(string stoppedAfter, string startedBefore, string token)
        {
            var response = await HttpClientHelper.Get($"/time-entries/{stoppedAfter}/{startedBefore}", token: token);
            return JsonConvert.DeserializeObject<TimeEntriesResponse>(response);
        }

        public async Task<TimeEntryResponse> CreateTimeEntry(TimeEntryCreationRequest request, string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var response = await HttpClientHelper.Post($"/time-entries/", jsonObject, token);
            return JsonConvert.DeserializeObject<TimeEntryResponse>(response);
        }

        public async Task<TimeEntryResponse> GetTimeEntry(string timeEntryId, string token)
        {
            var response = await HttpClientHelper.Get($"/time-entries/{timeEntryId}", token: token);
            return JsonConvert.DeserializeObject<TimeEntryResponse>(response);
        }

        public async Task<TimeEntryResponse> EditTimeEntry(string timeEntryId, TimeEntryEditionRequest request, string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Patch($"/time-entries/{timeEntryId}", jsonObject, token);
            return JsonConvert.DeserializeObject<TimeEntryResponse>(response);
        }

        public async Task<SuccessWithIgnoredErrorsResponse> DeleteTimeEntry(string timeEntryId, string token)
        {
            var response = await HttpClientHelper.Delete($"/time-entries/{timeEntryId}", token: token);
            return JsonConvert.DeserializeObject<SuccessWithIgnoredErrorsResponse>(response);
        }
    }
}
