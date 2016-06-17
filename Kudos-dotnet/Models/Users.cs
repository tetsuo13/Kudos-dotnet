using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    public class Users
    {
        [JsonProperty("schemas")]
        public IEnumerable<string> Schemas { get; set; }

        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }

        [JsonProperty("Resources")]
        public IEnumerable<User> Resources { get; set; }
    }
}
