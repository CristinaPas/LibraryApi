using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Repositories.RepositoryBaseClass;

namespace LibraryShopApi.Repositories
{
    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        private readonly LibraryShopApiDbContext _dbContext;
        private readonly PurchaseRepository _purchaseRepository;
        private readonly CancellationToken _cancellationToken;

        public PurchaseRepository(LibraryShopApiDbContext dbContext, PurchaseRepository purchaseRepository) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _purchaseRepository = purchaseRepository;
        }


        public async Task AddNewPurchase(PurchaseRequestDTO purchaseRequest)
        {
            if (purchaseRequest == null)
            {
                throw new ArgumentNullException(nameof(purchaseRequest));
            }
            else
            {
                _purchaseRepository.AddAsync(purchaseRequest, _cancellationToken);
                _dbContext.SaveChangesAsync();
            }
        }
    }
}
