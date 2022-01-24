﻿// <auto-generated />
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommanderGQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220123233017_FixSomeTypo")]
    partial class FixSomeTypo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CommanderGQL.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PerssonId")
                        .HasColumnType("int");

                    b.Property<int>("StarShipFlightId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StarShipFlightId");

                    b.HasIndex("PerssonId", "StarShipFlightId")
                        .IsUnique();

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("CommanderGQL.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PerssonId")
                        .HasColumnType("int");

                    b.Property<int>("StarShipFlightId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StarShipFlightId");

                    b.HasIndex("PerssonId", "StarShipFlightId")
                        .IsUnique();

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("CommanderGQL.Models.Persson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persson");
                });

            modelBuilder.Entity("CommanderGQL.Models.StarShipFlight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FlightNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StarShipFlights");
                });

            modelBuilder.Entity("CommanderGQL.Models.Crew", b =>
                {
                    b.HasOne("CommanderGQL.Models.Persson", "Persson")
                        .WithMany("crews")
                        .HasForeignKey("PerssonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderGQL.Models.StarShipFlight", "StarShipFlight")
                        .WithMany("crews")
                        .HasForeignKey("StarShipFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persson");

                    b.Navigation("StarShipFlight");
                });

            modelBuilder.Entity("CommanderGQL.Models.Passenger", b =>
                {
                    b.HasOne("CommanderGQL.Models.Persson", "Persson")
                        .WithMany("passengers")
                        .HasForeignKey("PerssonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CommanderGQL.Models.StarShipFlight", "StarShipFlight")
                        .WithMany("passengers")
                        .HasForeignKey("StarShipFlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persson");

                    b.Navigation("StarShipFlight");
                });

            modelBuilder.Entity("CommanderGQL.Models.Persson", b =>
                {
                    b.Navigation("crews");

                    b.Navigation("passengers");
                });

            modelBuilder.Entity("CommanderGQL.Models.StarShipFlight", b =>
                {
                    b.Navigation("crews");

                    b.Navigation("passengers");
                });
#pragma warning restore 612, 618
        }
    }
}