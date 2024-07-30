using Vehicle_Backend.Models.Enum;

namespace Vehicle_Backend.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int OwnerId { get; set; }
    }

}
