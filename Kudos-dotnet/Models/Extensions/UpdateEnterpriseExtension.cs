using Newtonsoft.Json;

namespace Kudos.Models.Extensions
{
    public class UpdateEnterpriseExtension
    {
        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("division")]
        public string Division { get; set; }
    }
}
