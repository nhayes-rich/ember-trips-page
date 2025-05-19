using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Leg
    {
        [JsonProperty("trip_uid")]
        public string TripUid { get; set; } = string.Empty;
    }

    public class Quote
    {
        [JsonProperty("legs")]
        public List<Leg> Legs { get; set; } = new();
    }

    public class QuotesResult
    {
        [JsonProperty("quotes")]
        public List<Quote> Quotes { get; set; } = new();
    }
    
}
