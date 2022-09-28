﻿// <auto-generated />
using System;
using HamsterDatabaseStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HamsterDatabaseStructure.Migrations
{
    [DbContext(typeof(HamsterDbContext))]
    partial class HamsterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HamsterDatabaseStructure.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcivityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcivityName = "CheckIn"
                        },
                        new
                        {
                            Id = 2,
                            AcivityName = "CheckOut"
                        },
                        new
                        {
                            Id = 3,
                            AcivityName = "ToCage"
                        },
                        new
                        {
                            Id = 4,
                            AcivityName = "ExerciseArea"
                        });
                });

            modelBuilder.Entity("HamsterDatabaseStructure.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int?>("HamsterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("HamsterId");

                    b.ToTable("ActivityLogs");
                });

            modelBuilder.Entity("HamsterDatabaseStructure.Cage", b =>
                {
                    b.Property<int>("CageID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxSize")
                        .HasColumnType("int");

                    b.HasKey("CageID");

                    b.ToTable("Cages");

                    b.HasData(
                        new
                        {
                            CageID = 1,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 2,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 3,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 4,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 5,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 6,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 7,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 8,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 9,
                            MaxSize = 3
                        },
                        new
                        {
                            CageID = 10,
                            MaxSize = 3
                        });
                });

            modelBuilder.Entity("HamsterDatabaseStructure.ExerciseArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ExerciseAreas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxSize = 6
                        });
                });

            modelBuilder.Entity("HamsterDatabaseStructure.Hamster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CageId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CheckInTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExerciseAreaId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("HamsterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LatestMotion")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CageId");

                    b.HasIndex("ExerciseAreaId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hamsters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 4,
                            Gender = "M",
                            HamsterName = "Rufus",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Age = 12,
                            Gender = "F",
                            HamsterName = "Lisa",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 3,
                            Age = 11,
                            Gender = "M",
                            HamsterName = "Fluff",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 4,
                            Age = 10,
                            Gender = "M",
                            HamsterName = "Nibbler",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 5,
                            Age = 9,
                            Gender = "M",
                            HamsterName = "Sneaky",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 6,
                            Age = 8,
                            Gender = "F",
                            HamsterName = "Sussi",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 7,
                            Age = 7,
                            Gender = "F",
                            HamsterName = "Mulan",
                            OwnerId = 4
                        },
                        new
                        {
                            Id = 8,
                            Age = 6,
                            Gender = "F",
                            HamsterName = "Miss Diggy",
                            OwnerId = 5
                        },
                        new
                        {
                            Id = 9,
                            Age = 5,
                            Gender = "M",
                            HamsterName = "Kalle",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 10,
                            Age = 4,
                            Gender = "M",
                            HamsterName = "Kurt",
                            OwnerId = 7
                        },
                        new
                        {
                            Id = 11,
                            Age = 4,
                            Gender = "F",
                            HamsterName = "Starlight",
                            OwnerId = 7
                        },
                        new
                        {
                            Id = 12,
                            Age = 3,
                            Gender = "M",
                            HamsterName = "Chivas",
                            OwnerId = 8
                        },
                        new
                        {
                            Id = 13,
                            Age = 3,
                            Gender = "F",
                            HamsterName = "Malin",
                            OwnerId = 9
                        },
                        new
                        {
                            Id = 14,
                            Age = 24,
                            Gender = "M",
                            HamsterName = "Bulle",
                            OwnerId = 10
                        },
                        new
                        {
                            Id = 15,
                            Age = 23,
                            Gender = "M",
                            HamsterName = "Beppe",
                            OwnerId = 11
                        },
                        new
                        {
                            Id = 16,
                            Age = 22,
                            Gender = "F",
                            HamsterName = "Bobo",
                            OwnerId = 12
                        },
                        new
                        {
                            Id = 17,
                            Age = 21,
                            Gender = "M",
                            HamsterName = "Robin",
                            OwnerId = 13
                        },
                        new
                        {
                            Id = 18,
                            Age = 20,
                            Gender = "F",
                            HamsterName = "Amber",
                            OwnerId = 14
                        },
                        new
                        {
                            Id = 19,
                            Age = 19,
                            Gender = "F",
                            HamsterName = "Kimber",
                            OwnerId = 15
                        },
                        new
                        {
                            Id = 20,
                            Age = 18,
                            Gender = "F",
                            HamsterName = "Ruby",
                            OwnerId = 16
                        },
                        new
                        {
                            Id = 21,
                            Age = 16,
                            Gender = "F",
                            HamsterName = "Fiffi",
                            OwnerId = 17
                        },
                        new
                        {
                            Id = 22,
                            Age = 16,
                            Gender = "F",
                            HamsterName = "Neko",
                            OwnerId = 18
                        },
                        new
                        {
                            Id = 23,
                            Age = 15,
                            Gender = "M",
                            HamsterName = "Clint",
                            OwnerId = 19
                        },
                        new
                        {
                            Id = 24,
                            Age = 14,
                            Gender = "M",
                            HamsterName = "Sauron",
                            OwnerId = 20
                        },
                        new
                        {
                            Id = 25,
                            Age = 12,
                            Gender = "F",
                            HamsterName = "Gittan",
                            OwnerId = 21
                        },
                        new
                        {
                            Id = 26,
                            Age = 110,
                            Gender = "M",
                            HamsterName = "Crawler",
                            OwnerId = 22
                        },
                        new
                        {
                            Id = 27,
                            Age = 9,
                            Gender = "F",
                            HamsterName = "Mimmi",
                            OwnerId = 23
                        },
                        new
                        {
                            Id = 28,
                            Age = 8,
                            Gender = "M",
                            HamsterName = "Marvel",
                            OwnerId = 24
                        },
                        new
                        {
                            Id = 29,
                            Age = 7,
                            Gender = "M",
                            HamsterName = "Storm",
                            OwnerId = 25
                        },
                        new
                        {
                            Id = 30,
                            Age = 6,
                            Gender = "F",
                            HamsterName = "Busan",
                            OwnerId = 26
                        });
                });

            modelBuilder.Entity("HamsterDatabaseStructure.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OwnerName = "Kallegurra Aktersnurra"
                        },
                        new
                        {
                            Id = 2,
                            OwnerName = "Carl Hamilton"
                        },
                        new
                        {
                            Id = 3,
                            OwnerName = "Lisa Nilsson"
                        },
                        new
                        {
                            Id = 4,
                            OwnerName = "Jan Hallgren"
                        },
                        new
                        {
                            Id = 5,
                            OwnerName = "Ottilla Murkwood"
                        },
                        new
                        {
                            Id = 6,
                            OwnerName = "Anfers Murkwood"
                        },
                        new
                        {
                            Id = 7,
                            OwnerName = "Anna Book"
                        },
                        new
                        {
                            Id = 8,
                            OwnerName = "Pernilla Wahlgren"
                        },
                        new
                        {
                            Id = 9,
                            OwnerName = "Bianca Ingrosso"
                        },
                        new
                        {
                            Id = 10,
                            OwnerName = "Lorenzo Lamas"
                        },
                        new
                        {
                            Id = 11,
                            OwnerName = "Bobby Ewing"
                        },
                        new
                        {
                            Id = 12,
                            OwnerName = "Hedy Lamar"
                        },
                        new
                        {
                            Id = 13,
                            OwnerName = "Bette Davis"
                        },
                        new
                        {
                            Id = 14,
                            OwnerName = "Kim Carnes"
                        },
                        new
                        {
                            Id = 15,
                            OwnerName = "Mork of Ork"
                        },
                        new
                        {
                            Id = 16,
                            OwnerName = "Mindy Mendel"
                        },
                        new
                        {
                            Id = 17,
                            OwnerName = "GW Hansson"
                        },
                        new
                        {
                            Id = 18,
                            OwnerName = "Pia Hansson"
                        },
                        new
                        {
                            Id = 19,
                            OwnerName = "Bo Ek"
                        },
                        new
                        {
                            Id = 20,
                            OwnerName = "Anna Al"
                        },
                        new
                        {
                            Id = 21,
                            OwnerName = "Hans Björk"
                        },
                        new
                        {
                            Id = 22,
                            OwnerName = "Carita Gran"
                        },
                        new
                        {
                            Id = 23,
                            OwnerName = "Mia Eriksson"
                        },
                        new
                        {
                            Id = 24,
                            OwnerName = "Anna Linström"
                        },
                        new
                        {
                            Id = 25,
                            OwnerName = "Lennart Berg"
                        },
                        new
                        {
                            Id = 26,
                            OwnerName = "Bo Bergman"
                        });
                });

            modelBuilder.Entity("HamsterDatabaseStructure.ActivityLog", b =>
                {
                    b.HasOne("HamsterDatabaseStructure.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("HamsterDatabaseStructure.Hamster", "Hamster")
                        .WithMany()
                        .HasForeignKey("HamsterId");

                    b.Navigation("Activity");

                    b.Navigation("Hamster");
                });

            modelBuilder.Entity("HamsterDatabaseStructure.Hamster", b =>
                {
                    b.HasOne("HamsterDatabaseStructure.Cage", "Cage")
                        .WithMany("Hamsters")
                        .HasForeignKey("CageId");

                    b.HasOne("HamsterDatabaseStructure.ExerciseArea", "ExerciseArea")
                        .WithMany("Hamster")
                        .HasForeignKey("ExerciseAreaId");

                    b.HasOne("HamsterDatabaseStructure.Owner", "Owner")
                        .WithMany("Hamsters")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cage");

                    b.Navigation("ExerciseArea");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("HamsterDatabaseStructure.Cage", b =>
                {
                    b.Navigation("Hamsters");
                });

            modelBuilder.Entity("HamsterDatabaseStructure.ExerciseArea", b =>
                {
                    b.Navigation("Hamster");
                });

            modelBuilder.Entity("HamsterDatabaseStructure.Owner", b =>
                {
                    b.Navigation("Hamsters");
                });
#pragma warning restore 612, 618
        }
    }
}