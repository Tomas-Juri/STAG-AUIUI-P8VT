using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("0c9051ee-2af3-4f28-be5f-a41b2e69f920"), new DateTime(2022, 2, 22, 22, 35, 33, 828, DateTimeKind.Local).AddTicks(1654), "Weather 2", 35 },
                    { new Guid("194ab9c2-ad76-4db9-b500-a4247c8ec782"), new DateTime(2021, 2, 22, 22, 35, 33, 828, DateTimeKind.Local).AddTicks(1541), "Weather 1", 30 },
                    { new Guid("adc6172a-0fa0-4067-8b1a-c675db0b396e"), new DateTime(2023, 2, 22, 22, 35, 33, 828, DateTimeKind.Local).AddTicks(1686), "Weather 3", 40 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("0c9051ee-2af3-4f28-be5f-a41b2e69f920"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("194ab9c2-ad76-4db9-b500-a4247c8ec782"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("adc6172a-0fa0-4067-8b1a-c675db0b396e"));
        }
    }
}
