using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlyShare.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

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
    }
}
