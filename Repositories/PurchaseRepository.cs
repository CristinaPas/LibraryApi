using LibraryShopApi.Data;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Repositories.RepositoryBaseClass;

namespace LibraryShopApi.Repositories;

public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
{
    private readonly LibraryShopApiDbContext _dbContext;
    private readonly CancellationToken _cancellationToken;

    public PurchaseRepository(LibraryShopApiDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }


    public async Task AddNewPurchase(Purchase purchaseRequest)
    {
        if (purchaseRequest == null)
        {
            throw new ArgumentNullException(nameof(purchaseRequest));
        }
        else
        {

            // Add the entity to the database
            await _dbContext.Purchases.AddAsync(purchaseRequest); //what is this doing?
            await _dbContext.SaveChangesAsync();
        }
    }
}
