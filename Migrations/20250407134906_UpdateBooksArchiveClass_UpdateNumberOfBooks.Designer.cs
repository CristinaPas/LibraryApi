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
    [Migration("20250407134906_UpdateBooksArchiveClass_UpdateNumberOfBooks")]
    partial class UpdateBooksArchiveClass_UpdateNumberOfBooks
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

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Harper Lee",
                            AvailabilityFlag = false,
                            Name = "To Kill a Mockingbird",
                            NumberOfBooks = 12,
                            Price = 14.99m
                        },
                        new
                        {
                            BookId = 2,
                            Author = "George Orwell",
                            AvailabilityFlag = false,
                            Name = "1984",
                            NumberOfBooks = 8,
                            Price = 19.99m
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Jane Austen",
                            AvailabilityFlag = false,
                            Name = "Pride and Prejudice",
                            NumberOfBooks = 10,
                            Price = 9.99m
                        },
                        new
                        {
                            BookId = 4,
                            Author = "F. Scott Fitzgerald",
                            AvailabilityFlag = false,
                            Name = "The Great Gatsby",
                            NumberOfBooks = 7,
                            Price = 13.99m
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Herman Melville",
                            AvailabilityFlag = false,
                            Name = "Moby Dick",
                            NumberOfBooks = 6,
                            Price = 17.99m
                        },
                        new
                        {
                            BookId = 6,
                            Author = "Leo Tolstoy",
                            AvailabilityFlag = false,
                            Name = "War and Peace",
                            NumberOfBooks = 5,
                            Price = 21.99m
                        },
                        new
                        {
                            BookId = 7,
                            Author = "J.D. Salinger",
                            AvailabilityFlag = false,
                            Name = "The Catcher in the Rye",
                            NumberOfBooks = 9,
                            Price = 12.99m
                        },
                        new
                        {
                            BookId = 8,
                            Author = "Fyodor Dostoevsky",
                            AvailabilityFlag = false,
                            Name = "Crime and Punishment",
                            NumberOfBooks = 4,
                            Price = 15.99m
                        },
                        new
                        {
                            BookId = 9,
                            Author = "J.R.R. Tolkien",
                            AvailabilityFlag = false,
                            Name = "The Hobbit",
                            NumberOfBooks = 11,
                            Price = 14.99m
                        },
                        new
                        {
                            BookId = 10,
                            Author = "Aldous Huxley",
                            AvailabilityFlag = false,
                            Name = "Brave New World",
                            NumberOfBooks = 8,
                            Price = 18.99m
                        });
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
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LibraryShopApi.Models.Entities.Purchase", b =>
                {
                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
