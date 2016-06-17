using Kudos.Models.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    /// <summary>
    /// Core user.
    /// </summary>
    public class User
    {
        [JsonProperty("schemas")]
        public IEnumerable<string> Schemas { get; set; }

        /// <summary>
        /// Unique identifier for the user as defined by Kudos.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// User email used to sign in to Kudos.
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }

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
        /// The user's title, such as Vice President.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Identifies if the user is active in Kudos.
        /// </summary>
        [JsonProperty("active")]
        public bool Active { get; set; }

        /// <summary>
        /// The components of the user's real name.
        /// </summary>
        [JsonProperty("name")]
        public UserName Name { get; set; }

        /// <summary>
        /// Email addresses for the user. The value SHOULD be canonicalized
        /// by the Service Provider, e.g. bjensen@example.com instead of
        /// bjensen@EXAMPLE.COM. Canonical Type values of work, home, and
        /// other.
        /// </summary>
        [JsonProperty("emails")]
        public IEnumerable<UserValue> Emails { get; set; }

        /// <summary>
        /// Phone numbers for the user. The value SHOULD be canonicalized by
        /// the Service Provider according to format in RFC3966 e.g.
        /// "tel:+1-201-555-0123." Canonical Type values of work, home,
        /// mobile, fax, pager, and other.
        /// </summary>
        [JsonProperty("phoneNumbers")]
        public IEnumerable<UserValue> PhoneNumbers { get; set; }

        /// <summary>
        /// A list of groups that the user belongs to.
        /// </summary>
        [JsonProperty("groups")]
        public IEnumerable<UserValue> Groups { get; set; }

        /// <summary>
        /// A list of roles for the user that collectively represent who the
        /// user is. Thie value has NO canonical types. Allowed values for
        /// <b>Value</b> are U, A, or SA where U = User, A = Admin, SA = Super
        /// Admin). The default for all users without a defined privilege is
        /// U.
        /// </summary>
        [JsonProperty("roles")]
        public IEnumerable<UserValue> Roles { get; set; }

        /// <summary>
        /// Numeric or alphanumeric identifier assigned to a person, typically
        /// based on order of hire or assiciation with an organization.
        /// </summary>
        [JsonProperty("employeeNumber")]
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// Properties specific to Kudos attributes.
        /// </summary>
        [JsonProperty("urn:scim:schemas:extension:kudos:1.0")]
        public KudosExtension Kudos { get; set; }

        /// <summary>
        /// Properties specific to enterprise attributes.
        /// </summary>
        [JsonProperty("urn:scim:schemas:extension:enterprise:1.0")]
        public EnterpriseExtension Enterprise { get; set; }

        [JsonProperty("meta")]
        public Metadata Metadata { get; set; }
    }
}
