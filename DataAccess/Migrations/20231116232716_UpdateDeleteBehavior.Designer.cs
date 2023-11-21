﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20231116232716_UpdateDeleteBehavior")]
    partial class UpdateDeleteBehavior
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Dalykas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("lecturerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("lecturerId");

                    b.ToTable("Dalykas");
                });

            modelBuilder.Entity("DataAccess.Marks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DalykoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfMark")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mark")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DalykoId");

                    b.HasIndex("StudentId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("DataAccess.Model.Programm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DalykoId")
                        .HasColumnType("int");

                    b.Property<int>("Kursas")
                        .HasColumnType("int");

                    b.Property<int>("Semestras")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DalykoId");

                    b.ToTable("Programm");
                });

            modelBuilder.Entity("DataAccess.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AsmPastas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fakultetas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gatve")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miestas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Premissions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudPastas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valstybe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DataAccess.Student", b =>
                {
                    b.HasBaseType("DataAccess.Person");

                    b.Property<string>("Grupe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kursas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Programa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Semestras")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("DataAccess.Dalykas", b =>
                {
                    b.HasOne("DataAccess.Person", "lecturer")
                        .WithMany()
                        .HasForeignKey("lecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("lecturer");
                });

            modelBuilder.Entity("DataAccess.Marks", b =>
                {
                    b.HasOne("DataAccess.Dalykas", "dalykas")
                        .WithMany()
                        .HasForeignKey("DalykoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Student", "student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dalykas");

                    b.Navigation("student");
                });

            modelBuilder.Entity("DataAccess.Model.Programm", b =>
                {
                    b.HasOne("DataAccess.Dalykas", "dalykas")
                        .WithMany()
                        .HasForeignKey("DalykoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("dalykas");
                });
#pragma warning restore 612, 618
        }
    }
}
