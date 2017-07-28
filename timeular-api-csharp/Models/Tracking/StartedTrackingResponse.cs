using System.Collections.Generic;

namespace timeular_api_csharp.Models.Tracking
{
    public class StartedTrackingResponse
    {
        public TrackingResponse CurrentTracking { get; set; }
        public List<ErrorResponse> Errors { get; set; }
    }
}
