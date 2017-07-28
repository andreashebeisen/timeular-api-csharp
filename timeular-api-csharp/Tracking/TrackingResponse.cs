namespace timeular_api_csharp.Tracking
{
    public class TrackingResponse
    {
        public TrackingActivityResponse Activity { get; set; }
        public string StartedAt { get; set; }
        public string Note { get; set; }
    }
}