using LibraryShopApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryShopApi.Data
{
    public class LibraryShopApiDbContext : DbContext
    {
        public LibraryShopApiDbContext(DbContextOptions<LibraryShopApiDbContext> options) : base(options)
        {
        }

        public DbSet<BooksArchive> BooksArchives { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<BooksArchive> list = [
                new BooksArchive { BookId = 1, Name = "To Kill a Mockingbird", Author = "Harper Lee", NumberOfBooks = 12, Price = 14.99m },
                new BooksArchive { BookId = 2, Name = "1984", Author = "George Orwell", NumberOfBooks = 8, Price = 19.99m },
                new BooksArchive { BookId = 3, Name = "Pride and Prejudice", Author = "Jane Austen", NumberOfBooks = 10, Price = 9.99m },
                new BooksArchive { BookId = 4, Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", NumberOfBooks = 7, Price = 13.99m },
                new BooksArchive { BookId = 5, Name = "Moby Dick", Author = "Herman Melville", NumberOfBooks = 6, Price = 17.99m },
                new BooksArchive { BookId = 6, Name = "War and Peace", Author = "Leo Tolstoy", NumberOfBooks = 5, Price = 21.99m },
                new BooksArchive { BookId = 7, Name = "The Catcher in the Rye", Author = "J.D. Salinger", NumberOfBooks = 9, Price = 12.99m },
                new BooksArchive { BookId = 8, Name = "Crime and Punishment", Author = "Fyodor Dostoevsky", NumberOfBooks = 4, Price = 15.99m },
                new BooksArchive { BookId = 9, Name = "The Hobbit", Author = "J.R.R. Tolkien", NumberOfBooks = 11, Price = 14.99m },
                new BooksArchive { BookId = 10, Name = "Brave New World", Author = "Aldous Huxley", NumberOfBooks = 8, Price = 18.99m }
                ];

            modelBuilder.Entity<BooksArchive>().HasData(list);
        }
    }
}
