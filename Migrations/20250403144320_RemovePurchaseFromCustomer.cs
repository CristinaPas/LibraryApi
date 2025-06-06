﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryShopApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovePurchaseFromCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 1,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 2,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 3,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 4,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 5,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 6,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 7,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 8,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 9,
                column: "AvailabilityFlag",
                value: false);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 10,
                column: "AvailabilityFlag",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 1,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 2,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 3,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 4,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 5,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 6,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 7,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 8,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 9,
                column: "AvailabilityFlag",
                value: true);

            migrationBuilder.UpdateData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 10,
                column: "AvailabilityFlag",
                value: true);
        }
    }
}
