using EmberTripsPage.Models.Interfaces;
using EmberTripsPage.Models.Json;

namespace EmberTripsPage.Models.Classes
{
    public class Stop(RouteStop routeStop) : IStop
    {
        private readonly RouteStop _routeStop = routeStop;

        public string GetFormattedDepartureEta(DateTime? routeStartTimeUtc = null)
        {
            string formattedTime = _routeStop.Departure.Scheduled.ToLocalTime().ToString("HH:mm");

            if (routeStartTimeUtc != null)
            {
                int daysAfter = (int)Math.Floor((_routeStop.Departure.Scheduled.ToLocalTime().Date - routeStartTimeUtc.Value.ToLocalTime().Date).TotalDays);

                if (daysAfter > 0)
                {
                    formattedTime += $"+{daysAfter}";
                }
            }

            return formattedTime;
        }

        public string GetName()
        {
            return _routeStop.Location.Name;
        }

        public string GetRegionName()
        {
            return _routeStop.Location.RegionName;
        }

        public ScheduledTime GetDeparture()
        {
            return _routeStop.Departure;
        }

        public Location GetLocation()
        {
            return _routeStop.Location;
        }
    }
}
