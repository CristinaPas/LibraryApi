﻿// <auto-generated />
using System;
using LibraryShopApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryShopApi.Migrations
{
    [DbContext(typeof(LibraryShopApiDbContext))]
    [Migration("20250321134404_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryShopApi.Models.Entities.BooksArchive", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AvailabilityFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBooks")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BookId");

                    b.ToTable("BooksArchives");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<DateTime>("PaymentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PaymentId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("PurchaseId");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Payment", b =>
                {
                    b.HasOne("LibraryShopApi.Models.Entities.Purchase", "Purchase")
                        .WithMany("Payment")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Purchase", b =>
                {
                    b.HasOne("LibraryShopApi.Models.Entities.BooksArchive", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryShopApi.Models.Entities.Customer", "Customer")
                        .WithMany("Purchase")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Customer", b =>
                {
                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Purchase", b =>
                {
                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
