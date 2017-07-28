namespace timeular_api_csharp.Tracking
{
    public class TimeEntryCreationRequest
    {
        public string ActivityId { get; set; }
        public string StartedAt { get; set; }
        public string StoppedAt { get; set; }
        public string Name { get; set; }
    }
}
