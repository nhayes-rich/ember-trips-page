using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Gps
    {
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("heading")]
        public int Heading { get; set; }
    }
}
