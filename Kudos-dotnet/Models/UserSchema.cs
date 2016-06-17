using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    public class UserSchema
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("schema")]
        public string Schema { get; set; }

        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("attributes")]
        public IEnumerable<UserSchemaAttribute> Attributes { get; set; }
    }
}
