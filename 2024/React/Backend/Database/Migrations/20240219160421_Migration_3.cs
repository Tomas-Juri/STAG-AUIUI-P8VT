using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class Migration_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("041fc995-1384-495e-9b0f-c5cc298bf277"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("18eadf00-e455-4ff3-ae87-9e01fd94f916"));

            migrationBuilder.DeleteData(
                table: "WeatherForecasts",
                keyColumn: "Id",
                keyValue: new Guid("60b0592d-faee-423c-85fc-10523e770eca"));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.InsertData(
                table: "WeatherForecasts",
                columns: new[] { "Id", "Date", "Summary", "TemperatureC" },
                values: new object[,]
                {
                    { new Guid("041fc995-1384-495e-9b0f-c5cc298bf277"), new DateTime(2022, 3, 10, 12, 21, 0, 564, DateTimeKind.Local).AddTicks(6897), "Weather 2", 35 },
                    { new Guid("18eadf00-e455-4ff3-ae87-9e01fd94f916"), new DateTime(2021, 3, 10, 12, 21, 0, 564, DateTimeKind.Local).AddTicks(6814), "Weather 1", 30 },
                    { new Guid("60b0592d-faee-423c-85fc-10523e770eca"), new DateTime(2023, 3, 10, 12, 21, 0, 564, DateTimeKind.Local).AddTicks(6906), "Weather 3", 40 }
                });
        }
    }
}
