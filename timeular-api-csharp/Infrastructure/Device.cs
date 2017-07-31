using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using timeular_api_csharp.Models.Tracking.Devices;

namespace timeular_api_csharp.Infrastructure
{
    public class Device
    {
        public async Task<DevicesResponse> GetDevices(string token)
        {
            var response = await HttpClientHelper.Get("/devices", token: token);
            return JsonConvert.DeserializeObject<DevicesResponse>(response);
        }

        public async Task<DeviceResponse> ActivateDevice(string deviceSerial, string token)
        {
            var response = await HttpClientHelper.Post($"/devices/{deviceSerial}/active", token: token);
            return JsonConvert.DeserializeObject<DeviceResponse>(response);
        }

        public async Task<DeviceResponse> DeactivateDevice(string deviceSerial, string token)
        {
            var response = await HttpClientHelper.Delete($"/devices/{deviceSerial}/active", token: token);
            return JsonConvert.DeserializeObject<DeviceResponse>(response);
        }

        public async Task<DeviceResponse> EditDevice(string deviceSerial, DeviceEditionRequest request, string token)
        {
            var jsonObject = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            var response = await HttpClientHelper.Patch($"/devices/{deviceSerial}", jsonObject, token);
            return JsonConvert.DeserializeObject<DeviceResponse>(response);
        }

        public async Task<DeviceResponse> ForgetDevice(string deviceSerial, string token)
        {
            var response = await HttpClientHelper.Delete($"/devices/{deviceSerial}", token: token);
            return JsonConvert.DeserializeObject<DeviceResponse>(response);
        }

        public async Task<DeviceResponse> DisableDevice(string deviceSerial, string token)
        {
            var response = await HttpClientHelper.Post($"/devices/{deviceSerial}/disabled", token: token);
            return JsonConvert.DeserializeObject<DeviceResponse>(response);
        }

        public async Task<DeviceResponse> EnableDevice(string deviceSerial, string token)
        {
            var response = await HttpClientHelper.Delete($"/devices/{deviceSerial}/disabled", token: token);
            return JsonConvert.DeserializeObject<DeviceResponse>(response);
        }
    }
}
