using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class ScheduledTime
    {
        [JsonProperty("scheduled")]
        public DateTime Scheduled { get; set; }

        [JsonProperty("actual")]
        public DateTime Actual { get; set; }

        [JsonProperty("estimated")]
        public DateTime Estimated { get; set; }
    }

    public class Location
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("region_name")]
        public string? RegionName { get; set; }

        [JsonProperty("detailed_name")]
        public string? DetailedName { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("google_place_id")]
        public string? GooglePlaceId { get; set; }
    }

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

        [JsonProperty("skipped")]
        public bool Skipped { get; set; }
    }

    public class Gps
    {
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("heading")]
        public int Heading { get; set; }
    }

    public class Vehicle
    {
        [JsonProperty("wheelchair")]
        public int Wheelchair { get; set; }

        [JsonProperty("bicycle")]
        public int Bicycle { get; set; }

        [JsonProperty("seat")]
        public int Seat { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("has_wifi")]
        public bool HasWifi { get; set; }

        [JsonProperty("has_toilet")]
        public bool HasToilet { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("brand")]
        public string? Brand { get; set; }

        [JsonProperty("colour")]
        public string? Colour { get; set; }

        [JsonProperty("gps")]
        public Gps? Gps { get; set; }
    }

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
    }

    public class TripResult
    {
        [JsonProperty("route")]
        public List<RouteStop>? Stops { get; set; }

        [JsonProperty("vehicle")]
        public Vehicle? Vehicle { get; set; }

        [JsonProperty("description")]
        public Description? Description { get; set; }
    }
}
