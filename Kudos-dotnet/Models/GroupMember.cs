using Newtonsoft.Json;

namespace Kudos.Models
{
    /// <summary>
    /// User detail associated with a group.
    /// </summary>
    public class GroupMember
    {
        /// <summary>
        /// A label indicating the function.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
  
        /// <summary>
        /// User id.
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }

        /// <summary>
        /// A human readable name, primarily used for display purposes.
        /// </summary>
        [JsonProperty("display")]
        public string Display { get; set; }

        /// <summary>
        /// Indicates the "primary" or preferred attribute value for this
        /// attribute.
        /// </summary>
        [JsonProperty("primary")]
        public bool? Primary { get; set; }
    }
}
