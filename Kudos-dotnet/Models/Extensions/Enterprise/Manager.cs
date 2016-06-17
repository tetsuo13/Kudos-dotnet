using Newtonsoft.Json;

namespace Kudos.Models.Extensions.Enterprise
{
    /// <summary>
    /// Identifies a user's manager.
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// The identifier of the user resource representing a user's
        /// manager.
        /// </summary>
        [JsonProperty("managerId")]
        public string Id { get; set; }

        /// <summary>
        /// The display name of a user's manager.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
    }
}
