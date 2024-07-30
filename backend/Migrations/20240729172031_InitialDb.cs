using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicle_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ServiceAdvisorId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRecords_Users_ServiceAdvisorId",
                        column: x => x.ServiceAdvisorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRecords_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceRecordId = table.Column<int>(type: "int", nullable: false),
                    WorkItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceItems_ServiceRecords_ServiceRecordId",
                        column: x => x.ServiceRecordId,
                        principalTable: "ServiceRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceItems_WorkItems_WorkItemId",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountStatus", "CreatedOn", "Email", "FirstName", "LastName", "MobileNumber", "Password", "UserType" },
                values: new object[,]
                {
                    { 1, "APPROVED", new DateTime(2023, 11, 1, 13, 28, 12, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin", "", "1234567890", "admin", "ADMIN" },
                    { 2, "UNAPPROVED", new DateTime(2024, 7, 29, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5153), "john.doe@example.com", "John", "Doe", "0987654321", "password", "SERVICE_ADVISOR" },
                    { 3, "APPROVED", new DateTime(2024, 7, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5166), "jane.smith@example.com", "Jane", "Smith", "2345678901", "password123", "SERVICE_ADVISOR" },
                    { 4, "SUSPENDED", new DateTime(2024, 7, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5172), "emily.johnson@example.com", "Emily", "Johnson", "3456789012", "password456", "SERVICE_ADVISOR" },
                    { 5, "UNAPPROVED", new DateTime(2024, 7, 14, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5174), "michael.williams@example.com", "Michael", "Williams", "4567890123", "password789", "SERVICE_ADVISOR" },
                    { 6, "APPROVED", new DateTime(2024, 7, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5176), "sarah.brown@example.com", "Sarah", "Brown", "5678901234", "password987", "SERVICE_ADVISOR" },
                    { 7, "SUSPENDED", new DateTime(2024, 7, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5178), "david.davis@example.com", "David", "Davis", "6789012345", "password654", "SERVICE_ADVISOR" },
                    { 8, "UNAPPROVED", new DateTime(2024, 6, 29, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5180), "laura.wilson@example.com", "Laura", "Wilson", "7890123456", "password321", "SERVICE_ADVISOR" },
                    { 9, "APPROVED", new DateTime(2024, 6, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5182), "daniel.moore@example.com", "Daniel", "Moore", "8901234567", "password246", "SERVICE_ADVISOR" },
                    { 10, "SUSPENDED", new DateTime(2024, 6, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5184), "olivia.taylor@example.com", "Olivia", "Taylor", "9012345678", "password135", "SERVICE_ADVISOR" },
                    { 11, "UNAPPROVED", new DateTime(2024, 6, 14, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5186), "ethan.anderson@example.com", "Ethan", "Anderson", "0123456789", "password864", "SERVICE_ADVISOR" },
                    { 12, "APPROVED", new DateTime(2024, 6, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5187), "ava.thomas@example.com", "Ava", "Thomas", "1234567890", "password753", "SERVICE_ADVISOR" },
                    { 13, "SUSPENDED", new DateTime(2024, 6, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5189), "james.jackson@example.com", "James", "Jackson", "2345678901", "password642", "SERVICE_ADVISOR" },
                    { 14, "UNAPPROVED", new DateTime(2024, 5, 30, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5191), "isabella.white@example.com", "Isabella", "White", "3456789012", "password531", "SERVICE_ADVISOR" },
                    { 15, "APPROVED", new DateTime(2024, 5, 25, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5193), "benjamin.harris@example.com", "Benjamin", "Harris", "4567890123", "password420", "SERVICE_ADVISOR" },
                    { 16, "SUSPENDED", new DateTime(2024, 5, 20, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5195), "sophia.martin@example.com", "Sophia", "Martin", "5678901234", "password309", "SERVICE_ADVISOR" },
                    { 17, "UNAPPROVED", new DateTime(2024, 5, 15, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5197), "jackson.thompson@example.com", "Jackson", "Thompson", "6789012345", "password198", "SERVICE_ADVISOR" },
                    { 18, "APPROVED", new DateTime(2024, 5, 10, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5199), "mia.garcia@example.com", "Mia", "Garcia", "7890123456", "password987", "SERVICE_ADVISOR" },
                    { 19, "SUSPENDED", new DateTime(2024, 5, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5200), "alexander.martinez@example.com", "Alexander", "Martinez", "8901234567", "password876", "SERVICE_ADVISOR" },
                    { 20, "UNAPPROVED", new DateTime(2024, 4, 30, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5202), "charlotte.roberts@example.com", "Charlotte", "Roberts", "9012345678", "password765", "SERVICE_ADVISOR" },
                    { 21, "APPROVED", new DateTime(2024, 4, 25, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5257), "henry.lee@example.com", "Henry", "Lee", "0123456789", "password654", "SERVICE_ADVISOR" },
                    { 22, "SUSPENDED", new DateTime(2024, 4, 20, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5260), "amelia.perez@example.com", "Amelia", "Perez", "1234567890", "password543", "SERVICE_ADVISOR" },
                    { 23, "UNAPPROVED", new DateTime(2024, 4, 15, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5261), "sebastian.young@example.com", "Sebastian", "Young", "2345678901", "password432", "SERVICE_ADVISOR" },
                    { 24, "APPROVED", new DateTime(2024, 4, 10, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5263), "harper.walker@example.com", "Harper", "Walker", "3456789012", "password321", "SERVICE_ADVISOR" },
                    { 25, "SUSPENDED", new DateTime(2024, 4, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5265), "oliver.hall@example.com", "Oliver", "Hall", "4567890123", "password210", "SERVICE_ADVISOR" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "LicensePlate", "Model", "OwnerId" },
                values: new object[,]
                {
                    { 1, "ABC123", "Model X", 2 },
                    { 2, "XYZ789", "Model Y", 2 },
                    { 3, "LMN456", "Model Z", 3 },
                    { 4, "PQR012", "Model A", 3 },
                    { 5, "STU345", "Model B", 4 },
                    { 6, "VWX678", "Model C", 4 },
                    { 7, "YZA901", "Model D", 5 },
                    { 8, "BCD234", "Model E", 5 },
                    { 9, "EFG567", "Model F", 6 },
                    { 10, "HIJ890", "Model G", 6 },
                    { 11, "KLM123", "Model H", 7 },
                    { 12, "NOP456", "Model I", 7 },
                    { 13, "QRS789", "Model J", 8 },
                    { 14, "TUV012", "Model K", 8 },
                    { 15, "WXY345", "Model L", 9 },
                    { 16, "ZAB678", "Model M", 9 },
                    { 17, "CDE901", "Model N", 10 },
                    { 18, "FGH234", "Model O", 10 },
                    { 19, "IJK567", "Model P", 11 },
                    { 20, "LMN890", "Model Q", 11 },
                    { 21, "OPQ123", "Model R", 12 },
                    { 22, "RST456", "Model S", 12 },
                    { 23, "UVW789", "Model T", 13 },
                    { 24, "XYZ012", "Model U", 13 },
                    { 25, "ABC345", "Model V", 14 }
                });

            migrationBuilder.InsertData(
                table: "WorkItems",
                columns: new[] { "Id", "Cost", "Name" },
                values: new object[,]
                {
                    { 1, 30.00m, "Oil Change" },
                    { 2, 40.00m, "Tire Rotation" },
                    { 3, 50.00m, "Brake Inspection" },
                    { 4, 70.00m, "Battery Replacement" },
                    { 5, 120.00m, "Engine Tune-Up" },
                    { 6, 150.00m, "Transmission Service" },
                    { 7, 60.00m, "Alignment" },
                    { 8, 20.00m, "Filter Replacement" },
                    { 9, 25.00m, "Fluid Check" },
                    { 10, 80.00m, "Suspension Check" },
                    { 11, 45.00m, "Headlight Replacement" },
                    { 12, 35.00m, "Tail Light Replacement" },
                    { 13, 100.00m, "Air Conditioning Service" },
                    { 14, 55.00m, "Radiator Flush" },
                    { 15, 75.00m, "Power Steering Service" },
                    { 16, 40.00m, "Serpentine Belt Replacement" },
                    { 17, 90.00m, "Water Pump Replacement" },
                    { 18, 200.00m, "Timing Belt Replacement" },
                    { 19, 85.00m, "Exhaust System Check" },
                    { 20, 95.00m, "Differential Service" },
                    { 21, 25.00m, "Windshield Wiper Replacement" },
                    { 22, 50.00m, "Rear Window Defogger Repair" },
                    { 23, 15.00m, "Fuse Replacement" },
                    { 24, 100.00m, "Wheel Bearing Replacement" },
                    { 25, 180.00m, "Turbocharger Service" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRecords",
                columns: new[] { "Id", "CompletedDate", "ScheduledDate", "ServiceAdvisorId", "Status", "VehicleId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5596), 3, 0, 1 },
                    { 2, new DateTime(2024, 7, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5599), new DateTime(2024, 7, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5598), 3, 2, 1 },
                    { 3, null, new DateTime(2024, 8, 12, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5603), 3, 1, 2 },
                    { 4, null, new DateTime(2024, 8, 1, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5604), 2, 0, 2 },
                    { 5, null, new DateTime(2024, 8, 18, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5606), 2, 1, 1 },
                    { 6, null, new DateTime(2024, 7, 30, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5607), 2, 0, 1 },
                    { 7, null, new DateTime(2024, 8, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5609), 2, 1, 2 },
                    { 8, new DateTime(2024, 7, 14, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5611), new DateTime(2024, 7, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5610), 2, 2, 1 },
                    { 9, null, new DateTime(2024, 8, 10, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5612), 2, 0, 2 },
                    { 10, null, new DateTime(2024, 8, 28, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5614), 2, 1, 1 },
                    { 11, null, new DateTime(2024, 8, 3, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5616), 2, 0, 2 },
                    { 12, null, new DateTime(2024, 8, 6, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5617), 2, 1, 1 },
                    { 13, new DateTime(2024, 7, 26, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5620), new DateTime(2024, 7, 21, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5619), 2, 2, 2 },
                    { 14, null, new DateTime(2024, 8, 8, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5621), 2, 0, 1 },
                    { 15, null, new DateTime(2024, 7, 31, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5622), 2, 1, 2 },
                    { 16, null, new DateTime(2024, 8, 7, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5624), 2, 0, 1 },
                    { 17, new DateTime(2024, 7, 29, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5626), new DateTime(2024, 7, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5625), 2, 2, 2 },
                    { 18, null, new DateTime(2024, 8, 13, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5627), 2, 1, 1 },
                    { 19, null, new DateTime(2024, 8, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5628), 2, 0, 2 },
                    { 20, null, new DateTime(2024, 8, 23, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5630), 2, 1, 1 },
                    { 21, null, new DateTime(2024, 8, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5631), 2, 0, 2 },
                    { 22, null, new DateTime(2024, 8, 2, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5632), 2, 1, 1 },
                    { 23, new DateTime(2024, 7, 22, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5634), new DateTime(2024, 7, 17, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5633), 2, 2, 2 },
                    { 24, null, new DateTime(2024, 8, 16, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5636), 2, 0, 1 },
                    { 25, null, new DateTime(2024, 8, 11, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5637), 2, 1, 2 },
                    { 26, null, new DateTime(2024, 8, 20, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5638), 2, 0, 1 },
                    { 27, null, new DateTime(2024, 8, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5640), 2, 1, 2 },
                    { 28, null, new DateTime(2024, 8, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5642), 2, 0, 1 },
                    { 29, new DateTime(2024, 7, 31, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5644), new DateTime(2024, 7, 26, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5643), 2, 2, 2 },
                    { 30, null, new DateTime(2024, 8, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5645), 2, 1, 1 },
                    { 31, null, new DateTime(2024, 8, 7, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5646), 2, 0, 2 },
                    { 32, null, new DateTime(2024, 8, 21, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5648), 2, 1, 1 },
                    { 33, null, new DateTime(2024, 8, 6, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5649), 2, 0, 2 },
                    { 34, null, new DateTime(2024, 8, 3, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6180), 2, 1, 1 },
                    { 35, new DateTime(2024, 7, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6187), new DateTime(2024, 7, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6187), 2, 2, 2 },
                    { 36, null, new DateTime(2024, 8, 14, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6189), 2, 0, 1 },
                    { 37, null, new DateTime(2024, 8, 12, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6191), 2, 1, 2 },
                    { 38, null, new DateTime(2024, 8, 21, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6192), 2, 0, 1 },
                    { 39, null, new DateTime(2024, 8, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6193), 2, 1, 2 },
                    { 40, null, new DateTime(2024, 8, 1, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6194), 2, 0, 1 },
                    { 41, new DateTime(2024, 7, 26, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6196), new DateTime(2024, 7, 21, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6196), 2, 2, 2 },
                    { 42, null, new DateTime(2024, 8, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6197), 2, 1, 1 },
                    { 43, null, new DateTime(2024, 8, 8, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6199), 2, 0, 2 },
                    { 44, null, new DateTime(2024, 8, 22, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6201), 2, 1, 1 },
                    { 45, null, new DateTime(2024, 8, 13, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(6202), 2, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "ServiceItems",
                columns: new[] { "Id", "Quantity", "ServiceRecordId", "WorkItemId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 2 },
                    { 3, 1, 2, 1 },
                    { 4, 3, 2, 2 },
                    { 5, 2, 3, 1 },
                    { 6, 1, 3, 2 },
                    { 7, 1, 4, 1 },
                    { 8, 2, 4, 2 },
                    { 9, 3, 5, 1 },
                    { 10, 2, 5, 2 },
                    { 11, 2, 6, 1 },
                    { 12, 1, 6, 2 },
                    { 13, 1, 7, 1 },
                    { 14, 3, 7, 2 },
                    { 15, 2, 8, 1 },
                    { 16, 1, 8, 2 },
                    { 17, 3, 9, 1 },
                    { 18, 2, 9, 2 },
                    { 19, 2, 10, 1 },
                    { 20, 1, 10, 2 },
                    { 21, 1, 11, 1 },
                    { 22, 2, 11, 2 },
                    { 23, 3, 12, 1 },
                    { 24, 2, 12, 2 },
                    { 25, 2, 13, 1 },
                    { 26, 1, 13, 2 },
                    { 27, 1, 14, 1 },
                    { 28, 3, 14, 2 },
                    { 29, 2, 15, 1 },
                    { 30, 1, 15, 2 },
                    { 31, 1, 16, 1 },
                    { 32, 2, 16, 2 },
                    { 33, 3, 17, 1 },
                    { 34, 2, 17, 2 },
                    { 35, 2, 18, 1 },
                    { 36, 1, 18, 2 },
                    { 37, 1, 19, 1 },
                    { 38, 2, 19, 2 },
                    { 39, 3, 20, 1 },
                    { 40, 2, 20, 2 },
                    { 41, 2, 21, 1 },
                    { 42, 1, 21, 2 },
                    { 43, 1, 22, 1 },
                    { 44, 3, 22, 2 },
                    { 45, 2, 23, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItems_ServiceRecordId",
                table: "ServiceItems",
                column: "ServiceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItems_WorkItemId",
                table: "ServiceItems",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecords_ServiceAdvisorId",
                table: "ServiceRecords",
                column: "ServiceAdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecords_VehicleId",
                table: "ServiceRecords",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceItems");

            migrationBuilder.DropTable(
                name: "ServiceRecords");

            migrationBuilder.DropTable(
                name: "WorkItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
