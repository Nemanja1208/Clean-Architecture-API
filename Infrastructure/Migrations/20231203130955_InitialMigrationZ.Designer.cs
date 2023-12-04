﻿// <auto-generated />
using System;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RealDatabase))]
    [Migration("20231203130955_InitialMigrationZ")]
    partial class InitialMigrationZ
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Dog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("45c243e1-4cd5-4a8d-a3c7-3ab070465b09"),
                            Name = "OldG"
                        },
                        new
                        {
                            Id = new Guid("0e4b7933-b58a-47e9-8cd9-92dbae7a59fe"),
                            Name = "NewG"
                        },
                        new
                        {
                            Id = new Guid("54203142-0668-4439-b9a3-071becf3c867"),
                            Name = "Björn"
                        },
                        new
                        {
                            Id = new Guid("9a324bf8-fa49-4e73-a2f0-ae215288ccde"),
                            Name = "Patrik"
                        },
                        new
                        {
                            Id = new Guid("4ae56968-1e85-4e3f-a40c-a654e9db32c5"),
                            Name = "Alfred"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345671"),
                            Name = "TestDogForUnitTests1"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345672"),
                            Name = "TestDogForUnitTests2"
                        },
                        new
                        {
                            Id = new Guid("12345678-1234-5678-1234-567812345673"),
                            Name = "TestDogForUnitTests3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
