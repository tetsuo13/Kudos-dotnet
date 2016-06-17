using Newtonsoft.Json;

namespace Kudos.Models
{
    /// <summary>
    /// Generic multi-value sub-attributes.
    /// </summary>
    public class UserValue
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// A human readable name, primarily used for display purposes.
        /// </summary>
        [JsonProperty("display")]
        public string Display { get; set; }

        /// <summary>
        /// A label indicating the attribute's function; e.g., "work" or
        /// "home."
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Indicates the "primary" or preferred attribute value for this
        /// attribute, e.g. the preferred mailing address or primery email
        /// address. The primary attribute value <see langword="true"/> MUST
        /// appear no more than once.
        /// </summary>
        [JsonProperty("primary")]
        public bool? Primary { get; set; }
    }
}
