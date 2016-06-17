using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kudos.Models
{
    public class ErrorResponse
    {
        [JsonProperty("Errors")]
        public IEnumerable<Error> Errors { get; set; }
    }
}
