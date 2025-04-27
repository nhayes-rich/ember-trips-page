using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class ZoneCoordinate
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
