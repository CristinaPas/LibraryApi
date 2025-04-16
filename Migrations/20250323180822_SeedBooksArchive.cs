using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryShopApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooksArchive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BooksArchives",
                columns: new[] { "BookId", "Author", "AvailabilityFlag", "Name", "NumberOfBooks", "Price" },
                values: new object[,]
                {
                    { 1, "Harper Lee", true, "To Kill a Mockingbird", 12, 14.99m },
                    { 2, "George Orwell", true, "1984", 8, 19.99m },
                    { 3, "Jane Austen", true, "Pride and Prejudice", 10, 9.99m },
                    { 4, "F. Scott Fitzgerald", true, "The Great Gatsby", 7, 13.99m },
                    { 5, "Herman Melville", true, "Moby Dick", 6, 17.99m },
                    { 6, "Leo Tolstoy", true, "War and Peace", 5, 21.99m },
                    { 7, "J.D. Salinger", true, "The Catcher in the Rye", 9, 12.99m },
                    { 8, "Fyodor Dostoevsky", true, "Crime and Punishment", 4, 15.99m },
                    { 9, "J.R.R. Tolkien", true, "The Hobbit", 11, 14.99m },
                    { 10, "Aldous Huxley", true, "Brave New World", 8, 18.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BooksArchives",
                keyColumn: "BookId",
                keyValue: 10);
        }
    }
}
