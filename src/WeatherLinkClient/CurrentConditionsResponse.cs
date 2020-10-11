using System.Text.Json.Serialization;

namespace WeatherLinkClient
{
    public class CurrentConditionsResponse
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; } = new Data();

        [JsonPropertyName("error")]
        public object Error { get; set; } = new object();
    }
}
