using Newtonsoft.Json;
using System;

namespace Kudos.Models.Extensions
{
    public class UpdateKudosExtension
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("kudosPoints")]
        public int? KudosPoints { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("jobDescription")]
        public string JobDescription { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }
    }
}
