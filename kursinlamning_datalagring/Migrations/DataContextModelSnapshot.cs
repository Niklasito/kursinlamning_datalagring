﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kursinlamning_datalagring.Contexts;

#nullable disable

namespace kursinlamning_datalagring.Migrations
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

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.CarOwnersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("char(13)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("CarOwners");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.CommentsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("ErrorReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ErrorReportId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.ErrorReportsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedFinished")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ErrorReports");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.ErrorStatusesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("ErrorStatuses");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.VehiclesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("CarRegistration")
                        .IsRequired()
                        .HasColumnType("char(6)");

                    b.HasKey("Id");

                    b.HasIndex("CarOwnerId");

                    b.HasIndex("CarRegistration")
                        .IsUnique();

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.CommentsEntity", b =>
                {
                    b.HasOne("kursinlamning_datalagring.Models.Entities.ErrorReportsEntity", "ErrorReport")
                        .WithMany("Comments")
                        .HasForeignKey("ErrorReportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ErrorReport");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.ErrorReportsEntity", b =>
                {
                    b.HasOne("kursinlamning_datalagring.Models.Entities.ErrorStatusesEntity", "ErrorStatus")
                        .WithMany("ErrorReports")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kursinlamning_datalagring.Models.Entities.VehiclesEntity", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ErrorStatus");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.VehiclesEntity", b =>
                {
                    b.HasOne("kursinlamning_datalagring.Models.Entities.CarOwnersEntity", "CarOwner")
                        .WithMany()
                        .HasForeignKey("CarOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarOwner");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.ErrorReportsEntity", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("kursinlamning_datalagring.Models.Entities.ErrorStatusesEntity", b =>
                {
                    b.Navigation("ErrorReports");
                });
#pragma warning restore 612, 618
        }
    }
}
