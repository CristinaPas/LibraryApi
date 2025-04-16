using LibraryShopApi.Data;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly LibraryShopApiDbContext _dbContext;

        public PurchaseRepository(LibraryShopApiDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Purchase> GetPurchaseByIdAsync(int id)
        {
            //do stuff
            //save db changes

            return await _dbContext.Purchases.FindAsync(id);
        }
    }
}
