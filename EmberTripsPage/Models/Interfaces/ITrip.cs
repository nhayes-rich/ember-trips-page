using EmberTripsPage.Models.Json;

namespace EmberTripsPage.Models.Interfaces
{
    public interface ITrip
    {
        public IEnumerable<IStop> GetStops();

        public IStop GetOrigin();

        public int GetCurrentStopIndex();

        public IStop GetCurrentStop();

        public IStop GetDestination();

        public string GetOriginName();

        public string GetOriginRegion();

        public DateTime GetStartTimeUTC();

        public string GetFormattedStartLocal();

        public string GetFormattedEndLocal();

        public string GetDestinationName();

        public string GetDestinationRegion();

        public StopType GetStopType(IStop stop);
    }
}
