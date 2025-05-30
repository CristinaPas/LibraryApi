using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Repositories.RepositoryBaseClass;

namespace LibraryShopApi.Repositories;

public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
{
    private readonly LibraryShopApiDbContext _dbContext;
    public CustomerRepository(LibraryShopApiDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task AddCustomerIntoTable(Customer customer) //example of task to be implemented
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DoesCustomerExist(PurchaseRequestDTO request) //example of task to be implemented
    {
        var result = _dbContext.Customers
                        .Where(c => c.Email == request.Email && c.FullName == request.FullName)
            .Select(c => new { c.Email, c.FullName })
            .FirstOrDefault();
        //    return await _dbContext.Customers
        //        .SingleOrDefaultAsync(c => c.Email == request.Email && c.FullName == request.FullName) != null;
        //
        return result != null;
    }

}
