using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherLinkClient
{
    public class Data
    {
        [JsonPropertyName("did")]
        public string Did { get; set; } = string.Empty;

        [JsonPropertyName("ts")]
        public long Ts { get; set; }

        [JsonPropertyName("conditions")]
        public List<Condition> Conditions { get; set; } = new List<Condition>();
    }
}
