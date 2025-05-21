using EmberTripsPage.Models.Json;

namespace EmberTripsPage.Models.Interfaces
{
    public interface IStop
    {
        public string GetFormattedDepartureEta(DateTime? routeStartTimeUtc = null);

        public string GetName();

        public string GetRegionName();

        public ScheduledTime GetDeparture();

        public Location GetLocation();
    }
}
