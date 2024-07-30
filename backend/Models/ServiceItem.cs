namespace Vehicle_Backend.Models
{
    public class ServiceItem
    {
        public int Id { get; set; }
        public int ServiceRecordId { get; set; }
        public ServiceRecord ServiceRecord { get; set; } // Foreign key relationship
        public int WorkItemId { get; set; }
        public WorkItem WorkItem { get; set; } // Foreign key relationship
        public int Quantity { get; set; }
    }

}
