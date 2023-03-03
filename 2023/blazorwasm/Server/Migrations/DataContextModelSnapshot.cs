﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlyShare.Server.Database;

#nullable disable

namespace OnlyShare.Server.Migrations
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

            modelBuilder.Entity("OnlyShare.Server.Database.Models.WeatherForecast", b =>
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
                            Id = new Guid("194ab9c2-ad76-4db9-b500-a4247c8ec782"),
                            Date = new DateTime(2021, 2, 22, 22, 35, 33, 828, DateTimeKind.Local).AddTicks(1541),
                            Summary = "Weather 1",
                            TemperatureC = 30
                        },
                        new
                        {
                            Id = new Guid("0c9051ee-2af3-4f28-be5f-a41b2e69f920"),
                            Date = new DateTime(2022, 2, 22, 22, 35, 33, 828, DateTimeKind.Local).AddTicks(1654),
                            Summary = "Weather 2",
                            TemperatureC = 35
                        },
                        new
                        {
                            Id = new Guid("adc6172a-0fa0-4067-8b1a-c675db0b396e"),
                            Date = new DateTime(2023, 2, 22, 22, 35, 33, 828, DateTimeKind.Local).AddTicks(1686),
                            Summary = "Weather 3",
                            TemperatureC = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}