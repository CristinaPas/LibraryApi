using LibraryShopApi.Data;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Repositories.RepositoryBaseClass;
using System.Diagnostics;

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
                Debug.WriteLine("Payment results in null, throwing exception");
                throw new ArgumentNullException(nameof(payment));
            }
            else
            {
                Debug.WriteLine("Add payment into Payment table");
                await _dbContext.Payment.AddAsync(payment, _cancellationToken);
                Debug.WriteLine("Save changes");
                await _dbContext.SaveChangesAsync(_cancellationToken);
            }

        }

    }
}
