using Kudos.Models.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    public class UpdateUser
    {
        [JsonProperty("schemas")]
        public IEnumerable<string> Schemas { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public UserName Name { get; set; }

        [JsonProperty("urn:scim:schemas:extension:kudos:1.0")]
        public UpdateKudosExtension Kudos { get; set; }

        [JsonProperty("urn:scim:schemas:extension:enterprise:1.0")]
        public UpdateEnterpriseExtension Enterprise { get; set; }
    }
}
