﻿// <auto-generated />
using System;
using Almostengr.PetFeeder.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Almostengr.PetFeeder.Web.Migrations
{
    [DbContext(typeof(PetFeederDbContext))]
    partial class PetFeederDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Almostengr.PetFeeder.Web.Models.Alarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Dismissed")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("alarm");
                });

            modelBuilder.Entity("Almostengr.PetFeeder.Web.Models.Feeding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("feeding");
                });

            modelBuilder.Entity("Almostengr.PetFeeder.Web.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("FeedingAmount")
                        .HasColumnType("double");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("IpAddress")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("Almostengr.PetFeeder.Web.Models.Setting", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("setting");
                });

            modelBuilder.Entity("Almostengr.PetFeeder.Web.Models.Watering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("watering");
                });
#pragma warning restore 612, 618
        }
    }
}