using Newtonsoft.Json;

namespace Kudos.Models
{
    public class SupportsFilter : Supports
    {
        [JsonProperty("maxResults")]
        public int MaxResults { get; set; }
    }
}
