using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryShopApi.Repositories
{
    public class BooksArchiveRepository : IBooksArchiveRepository
    {
        private readonly LibraryShopApiDbContext _dbContext;
        private readonly PurchaseRequestDTO _purchaseRequestDTO;

        public BooksArchiveRepository(LibraryShopApiDbContext dbContext, PurchaseRequestDTO purchaseRequestDTO)
        {
            _dbContext = dbContext; //?? throw new ArgumentNullException(nameof(dbContext));
            _purchaseRequestDTO = purchaseRequestDTO;
        }

        public async Task<decimal> GetBookPrice(string name)
        {
            var price = await _dbContext.BooksArchives
            .Where(b => b.Name == name)
            .Select(b => b.Price).FirstAsync();

            return price;
        }
        public async Task<bool> IsBookAvailable(string name)
        {
            bool isBookAvailable = await _dbContext.BooksArchives.
                SingleOrDefaultAsync(b => b.Name.ToLower() == name.ToLower() && b.NumberOfBooks > 0) != null;

            return isBookAvailable;
        }

        public async Task<int> NumberOfBooksInStore(string name)
        {
            var numberOfBooks = await _dbContext.BooksArchives
                .Where(b => b.Name == name)
                .Select(b => b.NumberOfBooks).FirstAsync();

            return numberOfBooks;
        }

        public async Task UpdateNumberOfBooks(PurchaseRequestDTO request)
        {
            var numberOfBooksPurchased = request.NumberOfBooksPurchased;
            await _dbContext.BooksArchives.Where(respositoryBooks => respositoryBooks.BookId == request.BookId)
                .ExecuteUpdateAsync(book => book.SetProperty(mybook => mybook.NumberOfBooks, mybook => mybook.NumberOfBooks - numberOfBooksPurchased));
            await _dbContext.SaveChangesAsync();
        }
    }

}
