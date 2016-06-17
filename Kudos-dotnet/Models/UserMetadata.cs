using Newtonsoft.Json;
using System;

namespace Kudos.Models
{
    public class Metadata
    {
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}