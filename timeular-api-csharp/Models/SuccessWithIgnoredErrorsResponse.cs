using System.Collections.Generic;

namespace timeular_api_csharp.Models
{
    public class SuccessWithIgnoredErrorsResponse
    {
        public List<ErrorResponse> Errors { get; set; }
    }
}
