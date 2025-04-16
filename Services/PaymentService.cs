using LibraryShopApi.Data;
using LibraryShopApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryShopApi.Services;

public class PaymentService
{
    private readonly LibraryShopApiDbContext _dbContext;

    public PaymentService(LibraryShopApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ProcessPayment(Purchase purchase)
    {
        //this goes in the repository
        var price = await _dbContext.BooksArchives
            .Where(b => b.BookId == purchase.BookId)
            .Select(b => b.Price).FirstAsync();

        var payment = new Payment
        {
            TotalPrice = price,
            Purchase = purchase,
            PaymentDateTime = DateTime.Now
        };

        //also this goes in the repository
        _dbContext.Payment.Add(payment);
        await _dbContext.SaveChangesAsync();
    }
}
