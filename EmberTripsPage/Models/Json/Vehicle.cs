using Newtonsoft.Json;

namespace EmberTripsPage.Models.Json
{
    public class Vehicle
    {
        [JsonProperty("wheelchair")]
        public int Wheelchair { get; set; }

        [JsonProperty("bicycle")]
        public int Bicycle { get; set; }

        [JsonProperty("seat")]
        public int Seat { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("plate_number")]
        public string? PlateNumber { get; set; }

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

        [JsonProperty("is_backup_vehicle")]
        public bool IsBackupVehicle { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty("gps")]
        public Gps? Gps { get; set; }
    }
}
