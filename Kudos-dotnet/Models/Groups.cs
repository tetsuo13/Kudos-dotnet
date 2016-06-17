using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    public class Groups
    {
        [JsonProperty("schemas")]
        public IEnumerable<string> Schemas { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("Resources")]
        public IEnumerable<Group> Resources { get; set; }
    }
}
