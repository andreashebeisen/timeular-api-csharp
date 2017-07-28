namespace timeular_api_csharp.Models.Tracking.Entries
{
    public class TimeEntryResponse
    {
        public string Id { get; set; }
        public TimeEntryActivityResponse Activity { get; set; }
        public TimeEntryDurationResponse Duration { get; set; }
        public string Note { get; set; }
    }
}