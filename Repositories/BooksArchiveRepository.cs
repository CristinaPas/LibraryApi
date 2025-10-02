using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Repositories.RepositoryBaseClass;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibraryShopApi.Repositories
{
    public class BooksArchiveRepository : RepositoryBase<BooksArchive>, IBooksArchiveRepository
    {
        private readonly LibraryShopApiDbContext _dbContext;

        public BooksArchiveRepository(LibraryShopApiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; //?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<decimal> GetBookPriceByName(string name)
        {
            decimal price = await _dbContext.BooksArchives
            .Where(b => b.Name == name)
            .Select(b => b.Price).FirstAsync();

            return price;
        }

        public async Task<decimal> GetBookPriceById(int id)
        {
            decimal price = await _dbContext.BooksArchives
            .Where(b => b.BookId == id)
            .Select(b => b.Price).FirstAsync();

            return price;
        }

        public async Task<int> GetBookIdByName(string bookName)
        {
            var bookId = await _dbContext.BooksArchives
                .Where(b => b.Name == bookName)
                .Select(b => b.BookId).FirstAsync();

            return bookId;
        }

        public async Task<bool> IsBookAvailable(string name)
            => await NumberOfBooksInStore(name) > 0;

        public async Task<bool> IsBookAvailableForPurchase(PurchaseRequestDTO request)
            => await _dbContext
                .BooksArchives
                .Where(book => book.Name.ToLower() == request.BookName.ToLower())
                .Select(book => book.NumberOfBooks >= request.NumberOfBooksPurchased ? true : false).FirstAsync();

        public async Task<int> NumberOfBooksInStore(string name)
            => await _dbContext.BooksArchives
                .Where(book => book.Name == name)
                .Select(book => book.NumberOfBooks).FirstAsync();

        public async Task UpdateNumberOfBooks(PurchaseRequestDTO request)
        {
            var numberOfBooksPurchased = request.NumberOfBooksPurchased;
            Debug.WriteLine(numberOfBooksPurchased.ToString());

            await _dbContext.BooksArchives.Where(respositoryBooks => respositoryBooks.Name == request.BookName)
                .ExecuteUpdateAsync(book => book.SetProperty(mybook => mybook.NumberOfBooks, mybook => mybook.NumberOfBooks - numberOfBooksPurchased));

            await _dbContext.SaveChangesAsync();
        }


    }

}
