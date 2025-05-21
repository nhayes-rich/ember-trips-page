using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Vehicle
    {
        [JsonProperty("wheelchair")]
        public int Wheelchair { get; set; }

        [JsonProperty("bicycle")]
        public int Bicycle { get; set; }

        [JsonProperty("seat")]
        public int Seat { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("has_wifi")]
        public bool HasWifi { get; set; }

        [JsonProperty("has_toilet")]
        public bool HasToilet { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("brand")]
        public string Brand { get; set; } = string.Empty;

        [JsonProperty("colour")]
        public string Colour { get; set; } = string.Empty;

        [JsonProperty("gps")]
        public Gps Gps { get; set; } = new();
    }
}
