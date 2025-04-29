using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Repositories.RepositoryBaseClass;
using System.Data.Entity;

namespace LibraryShopApi.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly LibraryShopApiDbContext _dbContext;
        public CustomerRepository(LibraryShopApiDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task AddCustomerIntoTable(Customer customer) //example of task to be implemented
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DoesCustomerExist(PurchaseRequestDTO request) //example of task to be implemented
        {
            bool doesCostumerExist = await _dbContext.Customers
                .SingleOrDefaultAsync(c => c.Email == request.Email && c.FullName == request.FullName) != null;
            return doesCostumerExist;
        }


    }

}
