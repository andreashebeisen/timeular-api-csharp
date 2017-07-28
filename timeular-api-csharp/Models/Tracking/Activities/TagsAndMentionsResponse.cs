using System.Collections.Generic;

namespace timeular_api_csharp.Models.Tracking.Activities
{
    public class TagsAndMentionsResponse
    {
        public List<TagResponse> Tags { get; set; }
        public List<MentionResponse> Mentions { get; set; }
        public List<ErrorResponse> Errors { get; set; }
    }
}
