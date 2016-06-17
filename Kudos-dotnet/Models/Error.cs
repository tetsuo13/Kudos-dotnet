using Newtonsoft.Json;

namespace Kudos.Models
{
    public class Error
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
