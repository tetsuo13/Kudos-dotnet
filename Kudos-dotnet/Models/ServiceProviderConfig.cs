using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    public class ServiceProviderConfig
    {
        [JsonProperty("schemas")]
        public IEnumerable<string> Schemas { get; set; }

        [JsonProperty("documentationUrl")]
        public string DocumentationUrl { get; set; }

        [JsonProperty("patch")]
        public Supports Patch { get; set; }

        [JsonProperty("bulk")]
        public SupportsBulk Bulk { get; set; }

        [JsonProperty("filter")]
        public SupportsFilter Filter { get; set; }

        [JsonProperty("changePassword")]
        public Supports ChangePassword { get; set; }

        [JsonProperty("sort")]
        public Supports Sort { get; set; }

        [JsonProperty("etag")]
        public Supports ETag { get; set; }

        [JsonProperty("xmlDataFormat")]
        public Supports XmlDataFormat { get; set; }

        [JsonProperty("authenticationSchemes")]
        public IEnumerable<Dictionary<string, string>> AuthenticationSchemes { get; set; }
    }
}
