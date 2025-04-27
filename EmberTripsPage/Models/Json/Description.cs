using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Description
    {
        [JsonProperty("route_number")]
        public string? RouteNumber { get; set; }

        [JsonProperty("pattern_id")]
        public int PatternId { get; set; }

        [JsonProperty("calendar_date")]
        public string? CalendarDate { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("is_cancelled")]
        public bool IsCancelled { get; set; }

        [JsonProperty("route_id")]
        public int RouteId { get; set; }
    }
}
