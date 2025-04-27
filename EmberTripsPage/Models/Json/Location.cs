using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Location
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("region_name")]
        public string? RegionName { get; set; }

        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("code_detail")]
        public string? CodeDetail { get; set; }

        [JsonProperty("detailed_name")]
        public string? DetailedName { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("google_place_id")]
        public string? GooglePlaceId { get; set; }

        [JsonProperty("atco_code")]
        public string? AtcoCode { get; set; }

        [JsonProperty("has_future_activity")]
        public bool HasFutureActivity { get; set; }

        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        [JsonProperty("zone")]
        public List<ZoneCoordinate>? Zone { get; set; }

        [JsonProperty("heading")]
        public int Heading { get; set; }

        [JsonProperty("area_id")]
        public int AreaId { get; set; }
    }
}
