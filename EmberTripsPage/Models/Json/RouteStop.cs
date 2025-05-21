using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class RouteStop
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("departure")]
        public ScheduledTime Departure { get; set; } = new();

        [JsonProperty("arrival")]
        public ScheduledTime Arrival { get; set; } = new();

        [JsonProperty("location")]
        public Location Location { get; set; } = new();

        [JsonProperty("allow_boarding")]
        public bool AllowBoarding { get; set; }

        [JsonProperty("allow_drop_off")]
        public bool AllowDropOff { get; set; }

        [JsonProperty("skipped")]
        public bool Skipped { get; set; }

        public string GetFormattedDepartureEta(DateTime? routeStartTimeUtc = null)
        {
            string formattedTime = Departure.Scheduled.ToLocalTime().ToString("HH:mm");

            if (routeStartTimeUtc != null)
            {
                int daysAfter = (int)Math.Floor((Departure.Scheduled.ToLocalTime().Date - routeStartTimeUtc.Value.ToLocalTime().Date).TotalDays);

                if (daysAfter > 0)
                {
                    formattedTime += $"+{daysAfter}";
                }
            }

            return formattedTime;
        }
    }
}
