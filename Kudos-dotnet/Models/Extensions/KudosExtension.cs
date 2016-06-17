using Newtonsoft.Json;
using System;

namespace Kudos.Models.Extensions
{
    /// <summary>
    /// Properties specific to Kudos. From the
    /// "urn:scim:schemas:extension:kudos:1.0" schema.
    /// </summary>
    public class KudosExtension
    {
        /// <summary>
        /// Unique identifier for the user as defined by the Service Consumer.
        /// The <see cref="User.ExternalId"/> may be a simplified
        /// identification of the user between the Service Consumer and
        /// Service provider by allowing the Consumer to refer to the user
        /// with its own identifier, obiating the need to store a local
        /// mapping between the local idenfitier of the user and the identifer
        /// used by the Service Provider.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Allocated Kudos points.
        /// </summary>
        [JsonProperty("kudosPoints")]
        public int KudosPoints { get; set; }

        /// <summary>
        /// User's birthday.
        /// </summary>
        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// User's start date.
        /// </summary>
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// User's job description.
        /// </summary>
        [JsonProperty("jobDescription")]
        public string JobDescription { get; set; }

        /// <summary>
        /// General notes about the user.
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
