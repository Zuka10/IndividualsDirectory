﻿// <auto-generated />
using System;
using IndividualsDirectory.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IndividualsDirectory.Infrastructure.Migrations
{
    [DbContext(typeof(IndividualsDbContext))]
    [Migration("20250315105422_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cities", t =>
                        {
                            t.HasCheckConstraint("CHK_CityName", "Name COLLATE Latin1_General_BIN NOT LIKE '%[ა-ჰ]%' OR Name COLLATE Georgian_Modern_Sort_BIN NOT LIKE '%[A-Za-z]%'");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Tbilisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "London"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Paris"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tokyo"
                        },
                        new
                        {
                            Id = 6,
                            Name = "New York"
                        });
                });

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Persons", t =>
                        {
                            t.HasCheckConstraint("CHK_BirthDate", "DATEDIFF(year, BirthDate, GETDATE()) >= 18");

                            t.HasCheckConstraint("CHK_FirstName", "FirstName COLLATE Latin1_General_BIN NOT LIKE '%[ა-ჰ]%' OR FirstName COLLATE Georgian_Modern_Sort_BIN NOT LIKE '%[A-Za-z]%'");

                            t.HasCheckConstraint("CHK_LastName", "LastName COLLATE Latin1_General_BIN NOT LIKE '%[ა-ჰ]%' OR LastName COLLATE Georgian_Modern_Sort_BIN NOT LIKE '%[A-Za-z]%'");

                            t.HasCheckConstraint("CHK_PersonalNumber", "LEN(PersonalNumber) = 11 AND PersonalNumber NOT LIKE '%[^0-9]%'");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            CityId = 1,
                            FirstName = "John",
                            Gender = 0,
                            LastName = "Doe",
                            PersonalNumber = "12345678910"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            CityId = 2,
                            FirstName = "Jane",
                            Gender = 0,
                            LastName = "Shpilman",
                            PersonalNumber = "12345678911"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            CityId = 3,
                            FirstName = "Jack",
                            Gender = 0,
                            LastName = "Nicholson",
                            PersonalNumber = "12345678912"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            CityId = 4,
                            FirstName = "Jill",
                            Gender = 0,
                            LastName = "James",
                            PersonalNumber = "12345678913"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            CityId = 5,
                            FirstName = "James",
                            Gender = 0,
                            LastName = "Jackson",
                            PersonalNumber = "12345678914"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            CityId = 6,
                            FirstName = "Jenny",
                            Gender = 0,
                            LastName = "Smith",
                            PersonalNumber = "12345678915"
                        });
                });

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberType")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PhoneNumbers", t =>
                        {
                            t.HasCheckConstraint("CHK_PhoneNumber", "LEN(Number) BETWEEN 4 AND 50");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "555-555-555",
                            NumberType = 0,
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            Number = "555-555-556",
                            NumberType = 0,
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            Number = "555-555-557",
                            NumberType = 0,
                            PersonId = 3
                        },
                        new
                        {
                            Id = 4,
                            Number = "555-555-558",
                            NumberType = 0,
                            PersonId = 4
                        },
                        new
                        {
                            Id = 5,
                            Number = "555-555-559",
                            NumberType = 0,
                            PersonId = 5
                        },
                        new
                        {
                            Id = 6,
                            Number = "555-555-560",
                            NumberType = 0,
                            PersonId = 6
                        });
                });

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.RelatedIndividual", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedPersonId")
                        .HasColumnType("int");

                    b.Property<int>("Relationship")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RelatedPersonId");

                    b.ToTable("RelatedIndividuals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PersonId = 1,
                            RelatedPersonId = 2,
                            Relationship = 0
                        },
                        new
                        {
                            Id = 2,
                            PersonId = 2,
                            RelatedPersonId = 3,
                            Relationship = 1
                        },
                        new
                        {
                            Id = 3,
                            PersonId = 3,
                            RelatedPersonId = 4,
                            Relationship = 1
                        },
                        new
                        {
                            Id = 4,
                            PersonId = 4,
                            RelatedPersonId = 5,
                            Relationship = 3
                        },
                        new
                        {
                            Id = 5,
                            PersonId = 5,
                            RelatedPersonId = 6,
                            Relationship = 3
                        },
                        new
                        {
                            Id = 6,
                            PersonId = 6,
                            RelatedPersonId = 1,
                            Relationship = 0
                        });
                });

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.Person", b =>
                {
                    b.HasOne("IndividualsDirectory.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("IndividualsDirectory.Domain.Entities.Person", "Person")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.RelatedIndividual", b =>
                {
                    b.HasOne("IndividualsDirectory.Domain.Entities.Person", "Person")
                        .WithMany("RelatedIndividuals")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndividualsDirectory.Domain.Entities.Person", "RelatedPerson")
                        .WithMany()
                        .HasForeignKey("RelatedPersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("RelatedPerson");
                });

            modelBuilder.Entity("IndividualsDirectory.Domain.Entities.Person", b =>
                {
                    b.Navigation("PhoneNumbers");

                    b.Navigation("RelatedIndividuals");
                });
#pragma warning restore 612, 618
        }
    }
}
