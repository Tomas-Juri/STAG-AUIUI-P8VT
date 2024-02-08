using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Migrations;

/// <inheritdoc />
public partial class SeedDataMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "WeatherForecasts",
            columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
            values: new object[,]
            {
                { new Guid("29f718ea-46fa-49e6-b817-4274c2c1b72e"), new DateTime(2022, 2, 22, 22, 51, 18, 213, DateTimeKind.Local).AddTicks(9178), "Weather 2", 35 },
                { new Guid("a8231101-8b54-41d3-af7e-5e2c40451022"), new DateTime(2021, 2, 22, 22, 51, 18, 213, DateTimeKind.Local).AddTicks(9076), "Weather 1", 30 },
                { new Guid("c3e49216-3db5-42e4-95bc-321d066aa902"), new DateTime(2023, 2, 22, 22, 51, 18, 213, DateTimeKind.Local).AddTicks(9192), "Weather 3", 40 }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "WeatherForecasts",
            keyColumn: "Id",
            keyValue: new Guid("29f718ea-46fa-49e6-b817-4274c2c1b72e"));

        migrationBuilder.DeleteData(
            table: "WeatherForecasts",
            keyColumn: "Id",
            keyValue: new Guid("a8231101-8b54-41d3-af7e-5e2c40451022"));

        migrationBuilder.DeleteData(
            table: "WeatherForecasts",
            keyColumn: "Id",
            keyValue: new Guid("c3e49216-3db5-42e4-95bc-321d066aa902"));
    }
}