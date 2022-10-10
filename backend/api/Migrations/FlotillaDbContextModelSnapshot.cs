﻿// <auto-generated />
using System;
using Api.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(FlotillaDbContext))]
    partial class FlotillaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Database.Models.Mission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssetCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EchoMissionId")
                        .HasMaxLength(128)
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("IsarMissionId")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("MissionStatus")
                        .HasColumnType("int");

                    b.Property<string>("RobotId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("RobotId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Api.Database.Models.Robot", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("BatteryLevel")
                        .HasColumnType("real");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Logs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Robots");
                });

            modelBuilder.Entity("Api.Database.Models.Mission", b =>
                {
                    b.HasOne("Api.Database.Models.Robot", "Robot")
                        .WithMany()
                        .HasForeignKey("RobotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Api.Database.Models.IsarTask", "Tasks", b1 =>
                        {
                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("IsarTaskId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("MissionId")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("TagId")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("TaskStatus")
                                .HasColumnType("int");

                            b1.Property<DateTimeOffset>("Time")
                                .HasColumnType("datetimeoffset");

                            b1.HasKey("Id");

                            b1.HasIndex("MissionId");

                            b1.ToTable("IsarTask");

                            b1.WithOwner("Mission")
                                .HasForeignKey("MissionId");

                            b1.OwnsMany("Api.Database.Models.IsarStep", "Steps", b2 =>
                                {
                                    b2.Property<string>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<string>("FileLocation")
                                        .HasMaxLength(128)
                                        .HasColumnType("nvarchar(128)");

                                    b2.Property<int>("InspectionType")
                                        .HasColumnType("int");

                                    b2.Property<string>("IsarStepId")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("StepStatus")
                                        .HasColumnType("int");

                                    b2.Property<int>("StepType")
                                        .HasColumnType("int");

                                    b2.Property<string>("TagId")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("TaskId")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<DateTimeOffset>("Time")
                                        .HasColumnType("datetimeoffset");

                                    b2.HasKey("Id");

                                    b2.HasIndex("TaskId");

                                    b2.ToTable("IsarStep");

                                    b2.WithOwner("Task")
                                        .HasForeignKey("TaskId");

                                    b2.Navigation("Task");
                                });

                            b1.Navigation("Mission");

                            b1.Navigation("Steps");
                        });

                    b.OwnsMany("Api.Database.Models.PlannedTask", "PlannedTasks", b1 =>
                        {
                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("MissionId")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("TagId")
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("URL")
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.HasKey("Id");

                            b1.HasIndex("MissionId");

                            b1.ToTable("PlannedTask");

                            b1.WithOwner()
                                .HasForeignKey("MissionId");

                            b1.OwnsMany("Api.Database.Models.PlannedInspection", "Inspections", b2 =>
                                {
                                    b2.Property<string>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<int>("InspectionType")
                                        .HasColumnType("int");

                                    b2.Property<string>("PlannedTaskId")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float?>("TimeInSeconds")
                                        .HasColumnType("real");

                                    b2.HasKey("Id");

                                    b2.HasIndex("PlannedTaskId");

                                    b2.ToTable("PlannedInspection");

                                    b2.WithOwner()
                                        .HasForeignKey("PlannedTaskId");
                                });

                            b1.Navigation("Inspections");
                        });

                    b.Navigation("PlannedTasks");

                    b.Navigation("Robot");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Api.Database.Models.Robot", b =>
                {
                    b.OwnsOne("Api.Database.Models.Pose", "Pose", b1 =>
                        {
                            b1.Property<string>("RobotId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Frame")
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.HasKey("RobotId");

                            b1.ToTable("Robots");

                            b1.WithOwner()
                                .HasForeignKey("RobotId");

                            b1.OwnsOne("Api.Database.Models.Orientation", "Orientation", b2 =>
                                {
                                    b2.Property<string>("PoseRobotId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("W")
                                        .HasColumnType("real");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseRobotId");

                                    b2.ToTable("Robots");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseRobotId");
                                });

                            b1.OwnsOne("Api.Database.Models.Position", "Position", b2 =>
                                {
                                    b2.Property<string>("PoseRobotId")
                                        .HasColumnType("nvarchar(450)");

                                    b2.Property<float>("X")
                                        .HasColumnType("real");

                                    b2.Property<float>("Y")
                                        .HasColumnType("real");

                                    b2.Property<float>("Z")
                                        .HasColumnType("real");

                                    b2.HasKey("PoseRobotId");

                                    b2.ToTable("Robots");

                                    b2.WithOwner()
                                        .HasForeignKey("PoseRobotId");
                                });

                            b1.Navigation("Orientation")
                                .IsRequired();

                            b1.Navigation("Position")
                                .IsRequired();
                        });

                    b.OwnsMany("Api.Database.Models.VideoStream", "VideoStreams", b1 =>
                        {
                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("nvarchar(64)");

                            b1.Property<string>("RobotId")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)");

                            b1.HasKey("Id");

                            b1.HasIndex("RobotId");

                            b1.ToTable("VideoStream");

                            b1.WithOwner()
                                .HasForeignKey("RobotId");
                        });

                    b.Navigation("Pose")
                        .IsRequired();

                    b.Navigation("VideoStreams");
                });
#pragma warning restore 612, 618
        }
    }
}