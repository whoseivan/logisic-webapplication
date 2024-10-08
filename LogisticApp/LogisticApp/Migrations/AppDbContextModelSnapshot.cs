﻿// <auto-generated />
using System;
using LogisticApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace LogisticApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogisticApp.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("LogisticApp.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("FuelConsumption")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<string>("Number")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("YearOfManufacture")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("LogisticApp.Models.Clients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("LogisticApp.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("City")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("LogisticApp.Models.Driver", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("firstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("lastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("middleName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("passport")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("LogisticApp.Models.Logistician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Passport")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Logisticians");
                });

            modelBuilder.Entity("LogisticApp.Models.Routes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ArrivalPoint")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("DeparturePoint")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("DistanceKm")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("FuelConsumption")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("LogisticApp.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ClientId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("DriverId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("LogisticianId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("RouteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DriverId");

                    b.HasIndex("LogisticianId");

                    b.HasIndex("RouteId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("LogisticApp.Models.Car", b =>
                {
                    b.HasOne("LogisticApp.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("LogisticApp.Models.Clients", b =>
                {
                    b.HasOne("LogisticApp.Models.Company", "Company")
                        .WithMany("Clients")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("LogisticApp.Models.Transaction", b =>
                {
                    b.HasOne("LogisticApp.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticApp.Models.Clients", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticApp.Models.Driver", "Driver")
                        .WithMany("Transactions")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticApp.Models.Logistician", "Logistician")
                        .WithMany("Transactions")
                        .HasForeignKey("LogisticianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogisticApp.Models.Routes", "Route")
                        .WithMany("Transactions")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Driver");

                    b.Navigation("Logistician");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("LogisticApp.Models.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("LogisticApp.Models.Clients", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("LogisticApp.Models.Company", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("LogisticApp.Models.Driver", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("LogisticApp.Models.Logistician", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("LogisticApp.Models.Routes", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
