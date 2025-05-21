using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class RouteStop
    {

        [JsonProperty("departure")]
        public ScheduledTime Departure { get; set; } = new();
        [JsonProperty("location")]
        public Location Location { get; set; } = new();
    }
}
