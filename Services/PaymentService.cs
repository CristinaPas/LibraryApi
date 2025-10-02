using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Interfaces.Services;
using LibraryShopApi.Models.Entities;
using System.Diagnostics;

namespace LibraryShopApi.Services;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IBooksArchiveRepository _booksArchiveRepository;

    public PaymentService(IPaymentRepository paymentRepository, IBooksArchiveRepository booksArchiveRepository)
    {
        _paymentRepository = paymentRepository;
        _booksArchiveRepository = booksArchiveRepository;
    }

    public async Task ProcessPayment(Purchase purchase)
    {
        var price = await _booksArchiveRepository.GetBookPriceById(purchase.BookId);
        Debug.WriteLine("Price: " + price.ToString());

        var payment = new Payment
        {
            TotalPrice = price,
            Purchase = purchase,
            PaymentDateTime = DateTime.Now
        };

        bool isPaymentSuccessful = await IsPaymentSuccessful(); //mock method
        Debug.WriteLine("Is paymnt successful: " + isPaymentSuccessful.ToString());

        if (!isPaymentSuccessful)
        {
            throw new Exception("Payment failed");
        }

        await _paymentRepository.AddPaymentIntoTable(payment);
    }

    public async Task<bool> IsPaymentSuccessful()
    {
        //mock logic
        return true;
    }
}
