using LibraryShopApi.Data;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Repositories.RepositoryBaseClass;

namespace LibraryShopApi.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        private readonly LibraryShopApiDbContext _dbContext;
        private readonly CancellationToken _cancellationToken;
        public PaymentRepository(LibraryShopApiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _cancellationToken = new CancellationToken();
        }

        public async Task AddPaymentIntoTable(Payment payment) //example of task to be implemented
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            else
            {
                await _dbContext.Payment.AddAsync(payment, _cancellationToken);
                await _dbContext.SaveChangesAsync(_cancellationToken);
            }

        }

    }
}
