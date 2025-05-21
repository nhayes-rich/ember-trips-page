using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
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

        public DateTime GetStartTimeUTC()
        {
            return GetOrigin().Departure.Scheduled.ToUniversalTime();
        }

        public DateTime GetEndTimeUTC()
        {
            return GetDestination().Departure.Scheduled.ToUniversalTime();
        }

        public string GetFormattedStartLocal()
        {
            return GetOrigin().GetFormattedDepartureEta();
        }

        public string GetFormattedEndLocal()
        {
            return GetDestination().GetFormattedDepartureEta(GetStartTimeUTC());
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
