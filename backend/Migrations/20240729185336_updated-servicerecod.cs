using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vehicle_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updatedservicerecod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ServiceItems",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 6, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3185));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 25, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3191), new DateTime(2024, 7, 20, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3190) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 13, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3195));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 2, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 5,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 19, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 6,
                column: "ScheduledDate",
                value: new DateTime(2024, 7, 31, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 7,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 6, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3203));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 15, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3206), new DateTime(2024, 7, 10, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3205) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 9,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 11, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 10,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 29, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 11,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 4, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 12,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 7, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 27, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3217), new DateTime(2024, 7, 22, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3216) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 14,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 9, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 15,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 1, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 16,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 8, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 30, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3227), new DateTime(2024, 7, 25, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3226) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 18,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 14, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3229));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 19,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 10, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3230));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 20,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 24, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3233));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 21,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 5, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 22,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 3, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3237));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 23, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3240), new DateTime(2024, 7, 18, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3239) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 24,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 17, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 25,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 12, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 30, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2464));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 20, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2479));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 25, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2486));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 15, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 10, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 5, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 30, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2498));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 25, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 20, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 15, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 10, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 5, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 31, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 26, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 21, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 16, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 11, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 6, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 1, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 26, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 21, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 16, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 11, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 6, 0, 23, 35, 166, DateTimeKind.Local).AddTicks(2546));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceItems",
                columns: new[] { "Id", "Quantity", "ServiceRecordId", "WorkItemId" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5596));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5599), new DateTime(2024, 7, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5598) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 12, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 1, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5604));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 5,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 18, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5606));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 6,
                column: "ScheduledDate",
                value: new DateTime(2024, 7, 30, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 7,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 14, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5611), new DateTime(2024, 7, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5610) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 9,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 10, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5612));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 10,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 28, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 11,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 3, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 12,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 6, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 26, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5620), new DateTime(2024, 7, 21, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5619) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 14,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 8, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 15,
                column: "ScheduledDate",
                value: new DateTime(2024, 7, 31, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 16,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 7, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 29, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5626), new DateTime(2024, 7, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5625) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 18,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 13, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 19,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 20,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 23, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 21,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 22,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 2, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CompletedDate", "ScheduledDate" },
                values: new object[] { new DateTime(2024, 7, 22, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5634), new DateTime(2024, 7, 17, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 24,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 16, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "ServiceRecords",
                keyColumn: "Id",
                keyValue: 25,
                column: "ScheduledDate",
                value: new DateTime(2024, 8, 11, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.InsertData(
                table: "ServiceRecords",
                columns: new[] { "Id", "CompletedDate", "ScheduledDate", "ServiceAdvisorId", "Status", "VehicleId" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 29, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5153));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5166));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 14, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5176));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 7, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 29, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 24, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 19, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 14, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 9, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedOn",
                value: new DateTime(2024, 6, 4, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 30, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 25, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 20, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 15, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5197));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 10, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedOn",
                value: new DateTime(2024, 5, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 30, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5202));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 20, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5260));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 15, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 10, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedOn",
                value: new DateTime(2024, 4, 5, 22, 50, 30, 141, DateTimeKind.Local).AddTicks(5265));
        }
    }
}
