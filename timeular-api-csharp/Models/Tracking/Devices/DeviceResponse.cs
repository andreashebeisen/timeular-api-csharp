namespace timeular_api_csharp.Models.Tracking.Devices
{
    public class DeviceResponse
    {
        public string Serial { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }
    }
}