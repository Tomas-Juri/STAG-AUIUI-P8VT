﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlyShare.Database;

#nullable disable

namespace OnlyShare.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlyShare.Database.Models.WeatherForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8231101-8b54-41d3-af7e-5e2c40451022"),
                            Date = new DateTime(2021, 2, 22, 22, 51, 18, 213, DateTimeKind.Local).AddTicks(9076),
                            Summary = "Weather 1",
                            TemperatureC = 30
                        },
                        new
                        {
                            Id = new Guid("29f718ea-46fa-49e6-b817-4274c2c1b72e"),
                            Date = new DateTime(2022, 2, 22, 22, 51, 18, 213, DateTimeKind.Local).AddTicks(9178),
                            Summary = "Weather 2",
                            TemperatureC = 35
                        },
                        new
                        {
                            Id = new Guid("c3e49216-3db5-42e4-95bc-321d066aa902"),
                            Date = new DateTime(2023, 2, 22, 22, 51, 18, 213, DateTimeKind.Local).AddTicks(9192),
                            Summary = "Weather 3",
                            TemperatureC = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}