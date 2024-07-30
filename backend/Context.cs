using Microsoft.EntityFrameworkCore;
using Vehicle_Backend.Models;
using Vehicle_Backend.Models.Enum;

namespace Vehicle_Backend
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<ServiceRecord>().ToTable("ServiceRecords");
            modelBuilder.Entity<WorkItem>().ToTable("WorkItems");
            modelBuilder.Entity<ServiceItem>().ToTable("ServiceItems");


            modelBuilder.Entity<WorkItem>()
                    .Property(w => w.Cost)
                    .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Admin", LastName = "", Email = "admin@gmail.com", MobileNumber = "1234567890", AccountStatus = AccountStatus.APPROVED, UserType = UserType.ADMIN, Password = "admin", CreatedOn = new DateTime(2023, 11, 01, 13, 28, 12) },
               
                // Service Advisors
                new User { Id = 2, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", MobileNumber = "0987654321", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password", CreatedOn = DateTime.Now },
                new User { Id = 3, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", MobileNumber = "2345678901", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password123", CreatedOn = DateTime.Now.AddDays(-10) },
                new User { Id = 4, FirstName = "Emily", LastName = "Johnson", Email = "emily.johnson@example.com", MobileNumber = "3456789012", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password456", CreatedOn = DateTime.Now.AddDays(-5) },

                new User { Id = 5, FirstName = "Michael", LastName = "Williams", Email = "michael.williams@example.com", MobileNumber = "4567890123", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password789", CreatedOn = DateTime.Now.AddDays(-15) },
                new User { Id = 6, FirstName = "Sarah", LastName = "Brown", Email = "sarah.brown@example.com", MobileNumber = "5678901234", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password987", CreatedOn = DateTime.Now.AddDays(-20) },
                new User { Id = 7, FirstName = "David", LastName = "Davis", Email = "david.davis@example.com", MobileNumber = "6789012345", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password654", CreatedOn = DateTime.Now.AddDays(-25) },
                new User { Id = 8, FirstName = "Laura", LastName = "Wilson", Email = "laura.wilson@example.com", MobileNumber = "7890123456", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password321", CreatedOn = DateTime.Now.AddDays(-30) },
                new User { Id = 9, FirstName = "Daniel", LastName = "Moore", Email = "daniel.moore@example.com", MobileNumber = "8901234567", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password246", CreatedOn = DateTime.Now.AddDays(-35) },
                new User { Id = 10, FirstName = "Olivia", LastName = "Taylor", Email = "olivia.taylor@example.com", MobileNumber = "9012345678", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password135", CreatedOn = DateTime.Now.AddDays(-40) },

                new User { Id = 11, FirstName = "Ethan", LastName = "Anderson", Email = "ethan.anderson@example.com", MobileNumber = "0123456789", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password864", CreatedOn = DateTime.Now.AddDays(-45) },
                new User { Id = 12, FirstName = "Ava", LastName = "Thomas", Email = "ava.thomas@example.com", MobileNumber = "1234567890", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password753", CreatedOn = DateTime.Now.AddDays(-50) },
                new User { Id = 13, FirstName = "James", LastName = "Jackson", Email = "james.jackson@example.com", MobileNumber = "2345678901", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password642", CreatedOn = DateTime.Now.AddDays(-55) },
                new User { Id = 14, FirstName = "Isabella", LastName = "White", Email = "isabella.white@example.com", MobileNumber = "3456789012", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password531", CreatedOn = DateTime.Now.AddDays(-60) },
                new User { Id = 15, FirstName = "Benjamin", LastName = "Harris", Email = "benjamin.harris@example.com", MobileNumber = "4567890123", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password420", CreatedOn = DateTime.Now.AddDays(-65) },
                new User { Id = 16, FirstName = "Sophia", LastName = "Martin", Email = "sophia.martin@example.com", MobileNumber = "5678901234", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password309", CreatedOn = DateTime.Now.AddDays(-70) },
                new User { Id = 17, FirstName = "Jackson", LastName = "Thompson", Email = "jackson.thompson@example.com", MobileNumber = "6789012345", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password198", CreatedOn = DateTime.Now.AddDays(-75) },
                new User { Id = 18, FirstName = "Mia", LastName = "Garcia", Email = "mia.garcia@example.com", MobileNumber = "7890123456", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password987", CreatedOn = DateTime.Now.AddDays(-80) },
                new User { Id = 19, FirstName = "Alexander", LastName = "Martinez", Email = "alexander.martinez@example.com", MobileNumber = "8901234567", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password876", CreatedOn = DateTime.Now.AddDays(-85) },
                new User { Id = 20, FirstName = "Charlotte", LastName = "Roberts", Email = "charlotte.roberts@example.com", MobileNumber = "9012345678", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password765", CreatedOn = DateTime.Now.AddDays(-90) },

                new User { Id = 21, FirstName = "Henry", LastName = "Lee", Email = "henry.lee@example.com", MobileNumber = "0123456789", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password654", CreatedOn = DateTime.Now.AddDays(-95) },
                new User { Id = 22, FirstName = "Amelia", LastName = "Perez", Email = "amelia.perez@example.com", MobileNumber = "1234567890", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password543", CreatedOn = DateTime.Now.AddDays(-100) },
                new User { Id = 23, FirstName = "Sebastian", LastName = "Young", Email = "sebastian.young@example.com", MobileNumber = "2345678901", AccountStatus = AccountStatus.UNAPPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password432", CreatedOn = DateTime.Now.AddDays(-105) },
                new User { Id = 24, FirstName = "Harper", LastName = "Walker", Email = "harper.walker@example.com", MobileNumber = "3456789012", AccountStatus = AccountStatus.APPROVED, UserType = UserType.SERVICE_ADVISOR, Password = "password321", CreatedOn = DateTime.Now.AddDays(-110) },
                new User { Id = 25, FirstName = "Oliver", LastName = "Hall", Email = "oliver.hall@example.com", MobileNumber = "4567890123", AccountStatus = AccountStatus.SUSPENDED, UserType = UserType.SERVICE_ADVISOR, Password = "password210", CreatedOn = DateTime.Now.AddDays(-115) }

            );

            // Seed Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, LicensePlate = "ABC123", Model = "Model X", OwnerId = 2 },
                new Vehicle { Id = 2, LicensePlate = "XYZ789", Model = "Model Y", OwnerId = 2 },
                new Vehicle { Id = 3, LicensePlate = "LMN456", Model = "Model Z", OwnerId = 3 },

                new Vehicle { Id = 4, LicensePlate = "PQR012", Model = "Model A", OwnerId = 3 },
                new Vehicle { Id = 5, LicensePlate = "STU345", Model = "Model B", OwnerId = 4 },
                new Vehicle { Id = 6, LicensePlate = "VWX678", Model = "Model C", OwnerId = 4 },
                new Vehicle { Id = 7, LicensePlate = "YZA901", Model = "Model D", OwnerId = 5 },
                new Vehicle { Id = 8, LicensePlate = "BCD234", Model = "Model E", OwnerId = 5 },
                new Vehicle { Id = 9, LicensePlate = "EFG567", Model = "Model F", OwnerId = 6 },
                
                new Vehicle { Id = 10, LicensePlate = "HIJ890", Model = "Model G", OwnerId = 6 },
                new Vehicle { Id = 11, LicensePlate = "KLM123", Model = "Model H", OwnerId = 7 },
                new Vehicle { Id = 12, LicensePlate = "NOP456", Model = "Model I", OwnerId = 7 },
                new Vehicle { Id = 13, LicensePlate = "QRS789", Model = "Model J", OwnerId = 8 },
                new Vehicle { Id = 14, LicensePlate = "TUV012", Model = "Model K", OwnerId = 8 },
                new Vehicle { Id = 15, LicensePlate = "WXY345", Model = "Model L", OwnerId = 9 },
                new Vehicle { Id = 16, LicensePlate = "ZAB678", Model = "Model M", OwnerId = 9 },

                new Vehicle { Id = 17, LicensePlate = "CDE901", Model = "Model N", OwnerId = 10 },
                new Vehicle { Id = 18, LicensePlate = "FGH234", Model = "Model O", OwnerId = 10 },
                new Vehicle { Id = 19, LicensePlate = "IJK567", Model = "Model P", OwnerId = 11 },
                new Vehicle { Id = 20, LicensePlate = "LMN890", Model = "Model Q", OwnerId = 11 },
                new Vehicle { Id = 21, LicensePlate = "OPQ123", Model = "Model R", OwnerId = 12 },
                new Vehicle { Id = 22, LicensePlate = "RST456", Model = "Model S", OwnerId = 12 },
                new Vehicle { Id = 23, LicensePlate = "UVW789", Model = "Model T", OwnerId = 13 },
                new Vehicle { Id = 24, LicensePlate = "XYZ012", Model = "Model U", OwnerId = 13 },
                new Vehicle { Id = 25, LicensePlate = "ABC345", Model = "Model V", OwnerId = 14 }
            );


            // Seed WorkItems
            modelBuilder.Entity<WorkItem>().HasData(
                new WorkItem { Id = 1, Name = "Oil Change", Cost = 30.00m },
                new WorkItem { Id = 2, Name = "Tire Rotation", Cost = 40.00m },
                new WorkItem { Id = 3, Name = "Brake Inspection", Cost = 50.00m },
                new WorkItem { Id = 4, Name = "Battery Replacement", Cost = 70.00m },
                new WorkItem { Id = 5, Name = "Engine Tune-Up", Cost = 120.00m },
                new WorkItem { Id = 6, Name = "Transmission Service", Cost = 150.00m },
                new WorkItem { Id = 7, Name = "Alignment", Cost = 60.00m },
                new WorkItem { Id = 8, Name = "Filter Replacement", Cost = 20.00m },
                new WorkItem { Id = 9, Name = "Fluid Check", Cost = 25.00m },
                new WorkItem { Id = 10, Name = "Suspension Check", Cost = 80.00m },
                new WorkItem { Id = 11, Name = "Headlight Replacement", Cost = 45.00m },
                new WorkItem { Id = 12, Name = "Tail Light Replacement", Cost = 35.00m },
                new WorkItem { Id = 13, Name = "Air Conditioning Service", Cost = 100.00m },
                new WorkItem { Id = 14, Name = "Radiator Flush", Cost = 55.00m },
                new WorkItem { Id = 15, Name = "Power Steering Service", Cost = 75.00m },
                new WorkItem { Id = 16, Name = "Serpentine Belt Replacement", Cost = 40.00m },
                new WorkItem { Id = 17, Name = "Water Pump Replacement", Cost = 90.00m },
                new WorkItem { Id = 18, Name = "Timing Belt Replacement", Cost = 200.00m },
                new WorkItem { Id = 19, Name = "Exhaust System Check", Cost = 85.00m },
                new WorkItem { Id = 20, Name = "Differential Service", Cost = 95.00m },
                new WorkItem { Id = 21, Name = "Windshield Wiper Replacement", Cost = 25.00m },
                new WorkItem { Id = 22, Name = "Rear Window Defogger Repair", Cost = 50.00m },
                new WorkItem { Id = 23, Name = "Fuse Replacement", Cost = 15.00m },
                new WorkItem { Id = 24, Name = "Wheel Bearing Replacement", Cost = 100.00m },
                new WorkItem { Id = 25, Name = "Turbocharger Service", Cost = 180.00m }
            // Add more work items as needed
            );

            // Seed ServiceRecords
            modelBuilder.Entity<ServiceRecord>().HasData(
                 new ServiceRecord { Id = 1, VehicleId = 1, ServiceAdvisorId = 3, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(7) },
                 new ServiceRecord { Id = 2, VehicleId = 1, ServiceAdvisorId = 3, Status = ServiceStatus.COMPLETED, ScheduledDate = DateTime.Now.AddDays(-10), CompletedDate = DateTime.Now.AddDays(-5) },
                 new ServiceRecord { Id = 3, VehicleId = 2, ServiceAdvisorId = 3, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(14) },
                 new ServiceRecord { Id = 4, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(3) },
                 new ServiceRecord { Id = 5, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(20) },
                 new ServiceRecord { Id = 6, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(1) },
                 new ServiceRecord { Id = 7, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(7) },
                 new ServiceRecord { Id = 8, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.COMPLETED, ScheduledDate = DateTime.Now.AddDays(-20), CompletedDate = DateTime.Now.AddDays(-15) },
                 new ServiceRecord { Id = 9, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(12) },
                 new ServiceRecord { Id = 10, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(30) },
                 new ServiceRecord { Id = 11, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(5) },
                 new ServiceRecord { Id = 12, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(8) },
                 new ServiceRecord { Id = 13, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.COMPLETED, ScheduledDate = DateTime.Now.AddDays(-8), CompletedDate = DateTime.Now.AddDays(-3) },
                 new ServiceRecord { Id = 14, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(10) },
                 new ServiceRecord { Id = 15, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(2) },
                 new ServiceRecord { Id = 16, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(9) },
                 new ServiceRecord { Id = 17, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.COMPLETED, ScheduledDate = DateTime.Now.AddDays(-5), CompletedDate = DateTime.Now },
                 new ServiceRecord { Id = 18, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(15) },
                 new ServiceRecord { Id = 19, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(11) },
                 new ServiceRecord { Id = 20, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(25) },
                 new ServiceRecord { Id = 21, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(6) },
                 new ServiceRecord { Id = 22, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(4) },
                 new ServiceRecord { Id = 23, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.COMPLETED, ScheduledDate = DateTime.Now.AddDays(-12), CompletedDate = DateTime.Now.AddDays(-7) },
                 new ServiceRecord { Id = 24, VehicleId = 1, ServiceAdvisorId = 2, Status = ServiceStatus.DUE, ScheduledDate = DateTime.Now.AddDays(18) },
                 new ServiceRecord { Id = 25, VehicleId = 2, ServiceAdvisorId = 2, Status = ServiceStatus.UNDER_SERVICE, ScheduledDate = DateTime.Now.AddDays(13) }
            );

            // Seed ServiceItems
            modelBuilder.Entity<ServiceItem>().HasData(
                new ServiceItem { Id = 1, ServiceRecordId = 1, WorkItemId = 1, Quantity = 1 },
                new ServiceItem { Id = 2, ServiceRecordId = 1, WorkItemId = 2, Quantity = 2 },
                new ServiceItem { Id = 3, ServiceRecordId = 2, WorkItemId = 1, Quantity = 1 },
                new ServiceItem { Id = 4, ServiceRecordId = 2, WorkItemId = 2, Quantity = 3 },
                new ServiceItem { Id = 5, ServiceRecordId = 3, WorkItemId = 1, Quantity = 2 },
                new ServiceItem { Id = 6, ServiceRecordId = 3, WorkItemId = 2, Quantity = 1 },
                new ServiceItem { Id = 7, ServiceRecordId = 4, WorkItemId = 1, Quantity = 1 },
                new ServiceItem { Id = 8, ServiceRecordId = 4, WorkItemId = 2, Quantity = 2 },
                new ServiceItem { Id = 9, ServiceRecordId = 5, WorkItemId = 1, Quantity = 3 },
                new ServiceItem { Id = 10, ServiceRecordId = 5, WorkItemId = 2, Quantity = 2 },
                new ServiceItem { Id = 11, ServiceRecordId = 6, WorkItemId = 1, Quantity = 2 },
                new ServiceItem { Id = 12, ServiceRecordId = 6, WorkItemId = 2, Quantity = 1 },
                new ServiceItem { Id = 13, ServiceRecordId = 7, WorkItemId = 1, Quantity = 1 },
                new ServiceItem { Id = 14, ServiceRecordId = 7, WorkItemId = 2, Quantity = 3 },
                new ServiceItem { Id = 15, ServiceRecordId = 8, WorkItemId = 1, Quantity = 2 },
                new ServiceItem { Id = 16, ServiceRecordId = 8, WorkItemId = 2, Quantity = 1 },
                new ServiceItem { Id = 17, ServiceRecordId = 9, WorkItemId = 1, Quantity = 3 },
                new ServiceItem { Id = 18, ServiceRecordId = 9, WorkItemId = 2, Quantity = 2 },
                new ServiceItem { Id = 19, ServiceRecordId = 10, WorkItemId = 1, Quantity = 2 },
                new ServiceItem { Id = 20, ServiceRecordId = 10, WorkItemId = 2, Quantity = 1 },
                new ServiceItem { Id = 21, ServiceRecordId = 11, WorkItemId = 1, Quantity = 1 },
                new ServiceItem { Id = 22, ServiceRecordId = 11, WorkItemId = 2, Quantity = 2 },
                new ServiceItem { Id = 23, ServiceRecordId = 12, WorkItemId = 1, Quantity = 3 },
                new ServiceItem { Id = 24, ServiceRecordId = 12, WorkItemId = 2, Quantity = 2 },
                new ServiceItem { Id = 25, ServiceRecordId = 13, WorkItemId = 1, Quantity = 2 }
                
            );

                 modelBuilder.Entity<ServiceRecord>()
                .HasOne(sr => sr.Vehicle)
                .WithMany()
                .HasForeignKey(sr => sr.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

                 modelBuilder.Entity<ServiceRecord>()
                .HasOne(sr => sr.ServiceAdvisor)
                .WithMany()
                .HasForeignKey(sr => sr.ServiceAdvisorId)
                .OnDelete(DeleteBehavior.Restrict);
            // Add more service items as needed


            // Call base method
            base.OnModelCreating(modelBuilder);
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<UserType>().HaveConversion<string>();
            configurationBuilder.Properties<AccountStatus>().HaveConversion<string>();
        }
    }
 }