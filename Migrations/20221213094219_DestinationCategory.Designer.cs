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
    [Migration("20221213094219_DestinationCategory")]
    partial class DestinationCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

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

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.DestinationCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("DestinationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("DestinationID");

                    b.ToTable("DestinationCategory");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.Destination", b =>
                {
                    b.HasOne("Proiect_Web_Onetiu_Malan.Models.City", "City")
                        .WithMany("Destinations")
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.DestinationCategory", b =>
                {
                    b.HasOne("Proiect_Web_Onetiu_Malan.Models.Category", "Category")
                        .WithMany("DestinationCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Web_Onetiu_Malan.Models.Destination", "Destination")
                        .WithMany("DestinationCategories")
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.Category", b =>
                {
                    b.Navigation("DestinationCategories");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.City", b =>
                {
                    b.Navigation("Destinations");
                });

            modelBuilder.Entity("Proiect_Web_Onetiu_Malan.Models.Destination", b =>
                {
                    b.Navigation("DestinationCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
