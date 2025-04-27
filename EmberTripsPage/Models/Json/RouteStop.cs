using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class RouteStop
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("departure")]
        public ScheduledTime? Departure { get; set; }

        [JsonProperty("arrival")]
        public ScheduledTime? Arrival { get; set; }

        [JsonProperty("location")]
        public Location? Location { get; set; }

        [JsonProperty("allow_boarding")]
        public bool AllowBoarding { get; set; }

        [JsonProperty("allow_drop_off")]
        public bool AllowDropOff { get; set; }

        [JsonProperty("booking_cut_off_mins")]
        public int BookingCutOffMins { get; set; }

        [JsonProperty("pre_booked_only")]
        public bool PreBookedOnly { get; set; }

        [JsonProperty("skipped")]
        public bool Skipped { get; set; }
    }
}
