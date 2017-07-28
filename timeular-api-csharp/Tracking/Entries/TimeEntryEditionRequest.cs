namespace timeular_api_csharp.Tracking
{
    public class TimeEntryEditionRequest
    {
        public string ActivityId { get; set; }
        public string StartedAt { get; set; }
        public string StoppedAt { get; set; }
        public string Note { get; set; }
    }
}
