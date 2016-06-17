using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    public class GroupSchemaAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("multiValued")]
        public bool MultiValued { get; set; }

        [JsonProperty("multiValuedAttributeChildName")]
        public string MultiValuedAttributeChildName { get; set; }

        [JsonProperty("plural")]
        public bool Plural { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("caseExact")]
        public bool CaseExact { get; set; }

        [JsonProperty("subAttributes")]
        public IEnumerable<GroupSchemaAttribute> SubAttributes { get; set; }

        [JsonProperty("canonicalValues")]
        public IEnumerable<string> CanonicalValues { get; set; }
    }
}
