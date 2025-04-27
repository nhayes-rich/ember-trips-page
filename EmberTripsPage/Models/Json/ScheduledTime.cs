using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class ScheduledTime
    {
        [JsonProperty("scheduled")]
        public DateTime Scheduled { get; set; }

        [JsonProperty("actual")]
        public DateTime Actual { get; set; }
    }
}
