using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("region_name")]
        public string RegionName { get; set; } = string.Empty;

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
