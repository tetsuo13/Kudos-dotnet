using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    /// <summary>
    /// Core group.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Unique identifier for the group resource as defined by Kudos.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Unique identifier as defined by Kudos.
        /// </summary>
        /// <remarks>
        /// It may simplify identification of users between Service Consumer
        /// and Service Provider by allowing the Consumer to refer to the user
        /// with its own identifier, obviating the need to store a local
        /// mapping between the local identifier of the user and the
        /// identifier used by the Service Provider. Each user MAY include a
        /// non-empty <see cref="ExternalId"/> value. The value of the
        /// <see cref="ExternalId"/> property is always issued by the Service
        /// Consumer and can never be specified by the Service Provider. This
        /// identifier MUST be unique across the Service Consumer's entire set
        /// of users. It MUST be a stable, non-reassignable identifier that
        /// does not change when the same user is returned in subsequence
        /// requests. The Service Provider MUST always interpret the
        /// <see cref="ExternalId"/> as scoped to the Service Consumer's
        /// tenant.
        /// </remarks>
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        /// <summary>
        /// The name of the group, suitable for display to end-users.
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("meta")]
        public Metadata Metadata { get; set; }

        /// <summary>
        /// A list of member of the group.
        /// </summary>
        /// <remarks>
        /// Canonical types "User" and "Group" are READ-ONLY. The value must
        /// be the "Id" of a user.
        /// </remarks>
        [JsonProperty("members")]
        public IEnumerable<GroupMember> Members { get; set; }
    }
}
