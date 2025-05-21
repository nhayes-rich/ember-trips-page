using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class TripResult
    {
        [JsonProperty("route")]
        public List<RouteStop> Stops { get; set; } = new();

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
