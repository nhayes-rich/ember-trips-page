using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class RouteStop
    {

        [JsonProperty("departure")]
        public ScheduledTime Departure { get; set; } = new();
        [JsonProperty("location")]
        public Location Location { get; set; } = new();

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
