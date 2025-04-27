using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Route
    {
        [JsonProperty("route")]
        public List<RouteStop>? Stops { get; set; }

        [JsonProperty("vehicle")]
        public Vehicle? Vehicle { get; set; }

        [JsonProperty("description")]
        public Description? Description { get; set; }
    }
}
