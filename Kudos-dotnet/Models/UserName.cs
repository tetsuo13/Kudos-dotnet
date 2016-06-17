using Newtonsoft.Json;

namespace Kudos.Models
{
    /// <summary>
    /// Contains the components of the user's real name.
    /// </summary>
    public class UserName
    {
        /// <summary>
        ///  The given name of the user, or first name in most Western
        /// languages (e.g. Barbara given the full name Ms. Barbara J Jensen,
        /// III.).
        /// </summary>
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// The family name of the user, or last name in most Western
        /// languages (e.g. Jensen given the full name Ms. Barbara J Jensen,
        /// III.).
        /// </summary>
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }
    }
}
