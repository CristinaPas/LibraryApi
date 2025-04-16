using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Services;

public class PurchaseService
{
    private readonly LibraryShopApiDbContext dbContext;
    //private readonly PaymentService paymentService;

    public PurchaseService(LibraryShopApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task ExecutePurchase(PurchaseRequest request)
    {
        var purchase = new Purchase
        {
            BookId = request.BookId,
            CustomerId = request.CustomerId,
            PurchaseDateTime = DateTime.Now
        };

        dbContext.Purchases.Add(purchase);
        await dbContext.SaveChangesAsync();

        // Triggers the payment logic
        PaymentService paymentService = new PaymentService(dbContext);
        await paymentService.ProcessPayment(purchase);

        // Triggers the Update Archive logic
        UpdateBooksArchiveService updateBooksArchiveService = new UpdateBooksArchiveService(dbContext, this);
        await updateBooksArchiveService.UpdateBooksArchive(request);
    }
}