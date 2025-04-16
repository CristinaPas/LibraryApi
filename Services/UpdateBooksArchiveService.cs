using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace LibraryShopApi.Services
{
    public class UpdateBooksArchiveService
    {
        private readonly LibraryShopApiDbContext dbContext;
        private readonly PurchaseService purchaseService;

        public UpdateBooksArchiveService(LibraryShopApiDbContext dbContext, PurchaseService purchaseService)
        {
            this.dbContext = dbContext;
            this.purchaseService = purchaseService;
        }

        public async Task UpdateBooksArchive(PurchaseRequest request)

        {
            //TO DO: allow purchase of multiple items at the same time
            //get all keys from the dictionary -> the books Ids
            //get all the numbers of book per books Ids -> how many books


            if (request != null)
            {
                await dbContext.BooksArchives.Where(respositoryBooks => respositoryBooks.BookId == request.BookId)
                    .ExecuteUpdateAsync(book => book.SetProperty(mybook => mybook.NumberOfBooks, mybook => mybook.NumberOfBooks - 1));
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("The books archival can't be updated, che the book availability");
            }

        }
    }
}




/*

        public async Task UpdateBookArchive(int bookId)
        {
            var book = await dbContext.BooksArchives.FindAsync(bookId);

            if (book != null)
            {
                book.NumberOfBooks--;
                dbContext.BooksArchives.Update(book);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Book not found.");
            }
        }
*/