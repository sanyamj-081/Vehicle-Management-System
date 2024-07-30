using Vehicle_Backend.Models.Enum;

namespace Vehicle_Backend.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } // Foreign key relationship
        public int ServiceAdvisorId { get; set; }
        public User ServiceAdvisor { get; set; } // Foreign key relationship
        public ServiceStatus Status { get; set; } = ServiceStatus.DUE;
        public DateTime ScheduledDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }

}
