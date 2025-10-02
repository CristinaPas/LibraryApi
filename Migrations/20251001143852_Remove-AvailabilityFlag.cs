using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryShopApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAvailabilityFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailabilityFlag",
                table: "BooksArchives");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AvailabilityFlag",
                table: "BooksArchives",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
