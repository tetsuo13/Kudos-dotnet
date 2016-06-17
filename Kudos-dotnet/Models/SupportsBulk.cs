using Newtonsoft.Json;

namespace Kudos.Models
{
    public class SupportsBulk : Supports
    {
        [JsonProperty("maxOperations")]
        public int MaxOperations { get; set; }

        [JsonProperty("maxPayloadSize")]
        public int MaxPayloadSize { get; set; }
    }
}
