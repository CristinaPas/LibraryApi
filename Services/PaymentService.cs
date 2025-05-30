using LibraryShopApi.Data;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Interfaces.Services;
using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IBooksArchiveRepository _booksArchiveRepository;
    private readonly LibraryShopApiDbContext _dbContext;


    public PaymentService(IPaymentRepository paymentRepository, IBooksArchiveRepository booksArchiveRepository, LibraryShopApiDbContext dbContext)
    {
        _paymentRepository = paymentRepository;
        _booksArchiveRepository = booksArchiveRepository;
        _dbContext = dbContext;
    }

    public async Task ProcessPayment(Purchase purchase)
    {
        var price = await _booksArchiveRepository.GetBookPriceById(purchase.BookId);

        var payment = new Payment
        {
            TotalPrice = price,
            Purchase = purchase,
            PaymentDateTime = DateTime.Now
        };

        bool isPaymentSuccessful = await IsPaymentSuccessful();

        if (!isPaymentSuccessful)
        {
            throw new Exception("Payment failed");
        }

        await _paymentRepository.AddPaymentIntoTable(payment);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<bool> IsPaymentSuccessful()
    {
        //mock logic
        return true;
    }
}
