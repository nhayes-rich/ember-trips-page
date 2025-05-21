using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class TripResult
    {
        [JsonProperty("route")]
        public List<RouteStop> Stops { get; set; } = new();
    }
}
