﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Web_Onetiu_Malan.Data;

#nullable disable

namespace Proiect_Web_Onetiu_Malan.Migrations
{
    [DbContext(typeof(Proiect_Web_Onetiu_MalanContext))]
    [Migration("20221212130811_City")]
    partial class City
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.Destination", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Destination");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.Destination", b =>
                {
                    b.HasOne("Proiect_Web_Onetiu_Malan.Models.City", "City")
                        .WithMany("Detinations")
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.City", b =>
                {
                    b.Navigation("Detinations");
                });
#pragma warning restore 612, 618
        }
    }
}