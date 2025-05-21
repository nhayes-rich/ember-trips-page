using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Location
    {
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("region_name")]
        public string RegionName { get; set; } = string.Empty;

        [JsonProperty("detailed_name")]
        public string DetailedName { get; set; } = string.Empty;

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("google_place_id")]
        public string GooglePlaceId { get; set; } = string.Empty;
    }
}
