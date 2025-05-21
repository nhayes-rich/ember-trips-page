using EmberTripsPage.Models.Interfaces;
using EmberTripsPage.Models.Json;

namespace EmberTripsPage.Models.Classes
{
    public class Trip : ITrip
    {
        private readonly TripResult _result;

        private readonly IEnumerable<IStop> _stops;

        public Trip(TripResult result)
        {
            _result = result;
            _stops = _result.Stops.Select(x => new Stop(x)).ToList();
        }

        public IEnumerable<IStop> GetStops()
        {
            return _stops;
        }

        public IStop GetOrigin()
        {
            return _stops.First();
        }

        public int GetCurrentStopIndex()
        {
            return _stops.Count() / 3;
        }

        public IStop GetCurrentStop()
        {
            return _stops.ElementAt(GetCurrentStopIndex());
        }

        public IStop GetDestination()
        {
            return _stops.Last();
        }

        public string GetOriginName()
        {
            return GetOrigin().GetName();
        }

        public string GetOriginRegion()
        {
            return GetOrigin().GetRegionName();
        }

        public DateTime GetStartTimeUTC()
        {
            return GetOrigin().GetDeparture().Scheduled.ToUniversalTime();
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
            return GetDestination().GetName();
        }

        public string GetDestinationRegion()
        {
            return GetDestination().GetRegionName();
        }

        public StopType GetStopType(IStop stop)
        {
            StopType stopType = StopType.INTERMEDIATE;

            if (stop.Equals(_stops.First()))
            {
                stopType = StopType.START;
            }
            else if (stop.Equals(_stops.Last()))
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
