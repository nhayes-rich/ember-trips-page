using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Description
    {
        [JsonProperty("route_number")]
        public string RouteNumber { get; set; } = string.Empty;

        [JsonProperty("pattern_id")]
        public int PatternId { get; set; }

        [JsonProperty("calendar_date")]
        public string CalendarDate { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("is_cancelled")]
        public bool IsCancelled { get; set; }
    }
}
