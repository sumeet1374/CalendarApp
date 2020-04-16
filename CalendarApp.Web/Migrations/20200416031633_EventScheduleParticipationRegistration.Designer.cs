﻿// <auto-generated />
using System;
using CalendarApp.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalendarApp.Web.Migrations
{
    [DbContext(typeof(CalendarAppDbContext))]
    [Migration("20200416031633_EventScheduleParticipationRegistration")]
    partial class EventScheduleParticipationRegistration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("CalendarApp.Model.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deleted = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Deleted = false,
                            Name = "Organizer"
                        },
                        new
                        {
                            Id = 3,
                            Deleted = false,
                            Name = "Participant"
                        });
                });

            modelBuilder.Entity("CalendarApp.Model.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Salt")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("CalendarApp.Model.EventParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventScheduleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventScheduleId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("EventParticipant");
                });

            modelBuilder.Entity("CalendarApp.Model.EventSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowParticipantsRegistration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AllowedParticipationLogs")
                        .HasColumnType("TEXT");

                    b.Property<bool>("AutoStartEndEvent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("NoOfParticipantsAllowed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrganizerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("EventSchedule");
                });

            modelBuilder.Entity("CalendarApp.Model.EventScheduleExecution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventScheduleId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FinishDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Started")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventScheduleId");

                    b.ToTable("EventScheduleExecution");
                });

            modelBuilder.Entity("CalendarApp.Model.Participation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventScheduleExecutionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Feedback")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Finished")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Started")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventScheduleExecutionId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Participation");
                });

            modelBuilder.Entity("CalendarApp.Model.ParticipationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LogTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("ParticipationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ParticipationId");

                    b.ToTable("ParticipationLog");
                });

            modelBuilder.Entity("CalendarApp.Model.AppUser", b =>
                {
                    b.HasOne("CalendarApp.Model.AppRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalendarApp.Model.EventParticipant", b =>
                {
                    b.HasOne("CalendarApp.Model.EventSchedule", "EventSchedule")
                        .WithMany("Participants")
                        .HasForeignKey("EventScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalendarApp.Model.AppUser", "Participant")
                        .WithMany("EventSchedules")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalendarApp.Model.EventSchedule", b =>
                {
                    b.HasOne("CalendarApp.Model.AppUser", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId");
                });

            modelBuilder.Entity("CalendarApp.Model.EventScheduleExecution", b =>
                {
                    b.HasOne("CalendarApp.Model.EventSchedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("EventScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalendarApp.Model.Participation", b =>
                {
                    b.HasOne("CalendarApp.Model.EventScheduleExecution", "EventScheduleExecution")
                        .WithMany("Participations")
                        .HasForeignKey("EventScheduleExecutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalendarApp.Model.AppUser", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalendarApp.Model.ParticipationLog", b =>
                {
                    b.HasOne("CalendarApp.Model.Participation", "Participation")
                        .WithMany("ParticipationLogs")
                        .HasForeignKey("ParticipationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
