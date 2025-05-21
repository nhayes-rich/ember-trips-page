using EmberTripsPage.Components.Pages;
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
        public string Type { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("region_name")]
        public string RegionName { get; set; } = string.Empty;

        [JsonProperty("detailed_name")]
        public string DetailedName { get; set; } = string.Empty;

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("google_place_id")]
        public string GooglePlaceId { get; set; } = string.Empty;
    }

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

        public string GetFormattedDepartureEta(DateTime routeStartTime)
        {
            int daysAfter = (int)Math.Floor((Departure.Scheduled.Date - routeStartTime.Date).TotalDays);

            string formattedTime = Departure.Scheduled.ToString("HH:mm");

            if (daysAfter > 0)
            {
                return formattedTime + $"+{daysAfter}";
            }

            return formattedTime;
        }
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
        public string Name { get; set; } = string.Empty;

        [JsonProperty("has_wifi")]
        public bool HasWifi { get; set; }

        [JsonProperty("has_toilet")]
        public bool HasToilet { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("brand")]
        public string Brand { get; set; } = string.Empty;

        [JsonProperty("colour")]
        public string Colour { get; set; } = string.Empty;

        [JsonProperty("gps")]
        public Gps Gps { get; set; } = new();
    }

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

    public class TripResult
    {
        [JsonProperty("route")]
        public List<RouteStop> Stops { get; set; } = new();

        [JsonProperty("vehicle")]
        public Vehicle Vehicle { get; set; } = new();

        [JsonProperty("description")]
        public Description Description { get; set; } = new();

        public string GetRouteNumber()
        {
            return Description.RouteNumber;
        }

        public string GetFormattedRouteName()
        {
            var firstName = GetOrigin().Location.Name;
            var firstRegion = GetOrigin().Location.RegionName;

            var lastName = GetDestination().Location.Name;
            var lastRegion = GetDestination().Location.RegionName;

            return $"{firstName} [{firstRegion}] to {lastName} [{lastRegion}]";
        }

        public RouteStop GetOrigin()
        {
            return Stops.First();
        }

        public int GetCurrentStopIndex()
        {
            return Stops.Count / 3;
        }

        public RouteStop GetCurrentStop()
        {
            return Stops[GetCurrentStopIndex()];
        }

        public RouteStop GetDestination()
        {
            return Stops.Last();
        }

        public string GetOriginName()
        {
            return GetOrigin().Location.Name;
        }

        public string GetOriginRegion()
        {
            return GetOrigin().Location.RegionName;
        }

        public DateTime GetStartTime()
        {
            return GetOrigin().Departure.Scheduled;
        }

        public DateTime GetEndTime()
        {
            return GetDestination().Departure.Scheduled;
        }

        public string GetFormattedStart()
        {
            return GetStartTime().ToString("HH:mm");
        }

        public string GetFormattedEnd()
        {
            return GetDestination().GetFormattedDepartureEta(GetStartTime());
        }

        public string GetDestinationName()
        {
            return GetDestination().Location.Name;
        }

        public string GetDestinationRegion()
        {
            return GetDestination().Location.RegionName;
        }

        public StopType GetStopType(RouteStop stop)
        {
            StopType stopType = StopType.INTERMEDIATE;
            
            if (stop.Equals(Stops.First()))
            {
                stopType = StopType.START;
            }
            else if (stop.Equals(Stops.Last()))
            {
                stopType = StopType.END;
            }
            else if (stop.Equals(GetCurrentStop()))
            {
                stopType = StopType.ACTIVE;
            }

            return stopType;
        }
    }
}
