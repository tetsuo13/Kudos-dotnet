using Kudos.Models.Extensions.Enterprise;
using Newtonsoft.Json;

namespace Kudos.Models.Extensions
{
    /// <summary>
    /// Properties specific to enterprise attributes. From the
    /// "urn:scim:schemas:extension:enterprise:1.0" schema.
    /// </summary>
    public class EnterpriseExtension
    {
        /// <summary>
        /// Identifies the name of a division.
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }

        /// <summary>
        /// Identifies the name of a division.
        /// </summary>
        [JsonProperty("division")]
        public string Division { get; set; }

        /// <summary>
        /// The user's manager.
        /// </summary>
        [JsonProperty("manager")]
        public Manager Manager { get; set; }
    }
}
