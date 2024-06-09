﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RGNRK.Data;

#nullable disable

namespace RGNRK.Migrations
{
    [DbContext(typeof(RGNRKContext))]
    [Migration("20240608145528_pcworkoutyreservas2")]
    partial class pcworkoutyreservas2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RGNRK.Data.Benchmark", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("PersonalRecords")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("Benchmarks");
                });

            modelBuilder.Entity("RGNRK.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Basico"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Gimnásticos"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Halterofilia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Accesorios"
                        });
                });

            modelBuilder.Entity("RGNRK.Data.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int?>("ExerciseVideoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ExerciseVideoId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("RGNRK.Data.PersonalCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PersonalCalendars");
                });

            modelBuilder.Entity("RGNRK.Data.PersonalCalendarReserva", b =>
                {
                    b.Property<int>("PersonalCalendarId")
                        .HasColumnType("int");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PersonalCalendarId", "ReservaId");

                    b.HasIndex("ReservaId");

                    b.ToTable("PersonalCalendarReservas");
                });

            modelBuilder.Entity("RGNRK.Data.PersonalCalendarWorkout", b =>
                {
                    b.Property<int>("PersonalCalendarId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PersonalCalendarId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("PersonalCalendarWorkouts");
                });

            modelBuilder.Entity("RGNRK.Data.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Entrenador")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Titulo")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("RGNRK.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserCategory")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RGNRK.Data.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("RGNRK.Data.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(3000)
                        .HasColumnType("varchar(3000)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RGNRK.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RGNRK.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RGNRK.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RGNRK.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RGNRK.Data.Benchmark", b =>
                {
                    b.HasOne("RGNRK.Data.Exercise", "Exercise")
                        .WithMany("Benchmarks")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RGNRK.Data.User", "User")
                        .WithMany("Benchmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RGNRK.Data.Exercise", b =>
                {
                    b.HasOne("RGNRK.Data.Category", "Category")
                        .WithMany("Exercises")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RGNRK.Data.Video", "ExerciseVideo")
                        .WithMany()
                        .HasForeignKey("ExerciseVideoId");

                    b.Navigation("Category");

                    b.Navigation("ExerciseVideo");
                });

            modelBuilder.Entity("RGNRK.Data.PersonalCalendarReserva", b =>
                {
                    b.HasOne("RGNRK.Data.PersonalCalendar", "PersonalCalendar")
                        .WithMany("PersonalCalendarReservas")
                        .HasForeignKey("PersonalCalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RGNRK.Data.Reserva", "Reserva")
                        .WithMany("PersonalCalendarReservas")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalCalendar");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("RGNRK.Data.PersonalCalendarWorkout", b =>
                {
                    b.HasOne("RGNRK.Data.PersonalCalendar", "PersonalCalendar")
                        .WithMany("PersonalCalendarWorkouts")
                        .HasForeignKey("PersonalCalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RGNRK.Data.Workout", "Workout")
                        .WithMany("PersonalCalendarWorkouts")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalCalendar");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("RGNRK.Data.Reserva", b =>
                {
                    b.HasOne("RGNRK.Data.User", "User")
                        .WithMany("Reservas")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RGNRK.Data.Workout", b =>
                {
                    b.HasOne("RGNRK.Data.Exercise", null)
                        .WithMany("Workout")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RGNRK.Data.Category", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("RGNRK.Data.Exercise", b =>
                {
                    b.Navigation("Benchmarks");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("RGNRK.Data.PersonalCalendar", b =>
                {
                    b.Navigation("PersonalCalendarReservas");

                    b.Navigation("PersonalCalendarWorkouts");
                });

            modelBuilder.Entity("RGNRK.Data.Reserva", b =>
                {
                    b.Navigation("PersonalCalendarReservas");
                });

            modelBuilder.Entity("RGNRK.Data.User", b =>
                {
                    b.Navigation("Benchmarks");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("RGNRK.Data.Workout", b =>
                {
                    b.Navigation("PersonalCalendarWorkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
