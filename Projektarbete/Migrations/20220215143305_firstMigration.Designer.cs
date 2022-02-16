﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projektarbete.Data;

#nullable disable

namespace Projektarbete.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220215143305_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Projektarbete.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Inside")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Outside")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Projektarbete.Models.OpeningHours", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClosingHour")
                        .HasColumnType("int");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OpeningHour")
                        .HasColumnType("int");

                    b.Property<string>("Weekday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("OpeningHours");
                });

            modelBuilder.Entity("Projektarbete.Models.OpeningHours", b =>
                {
                    b.HasOne("Projektarbete.Models.Event", "Event")
                        .WithMany("OpeningHours")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Projektarbete.Models.Event", b =>
                {
                    b.Navigation("OpeningHours");
                });
#pragma warning restore 612, 618
        }
    }
}