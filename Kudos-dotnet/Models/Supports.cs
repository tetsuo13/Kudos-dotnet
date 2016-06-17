using Newtonsoft.Json;

namespace Kudos.Models
{
    public class Supports
    {
        [JsonProperty("supported")]
        public bool Supported { get; set; }
    }
}
