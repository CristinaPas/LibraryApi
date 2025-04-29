using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Services;

public class PurchaseService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IBooksArchiveRepository _booksArchiveRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly LibraryShopApiDbContext _dbContext;

    public PurchaseService(IPaymentRepository paymentRepository, IPurchaseRepository purchaseRepository,
        IBooksArchiveRepository booksArchiveRepository, ICustomerRepository customerRepository, LibraryShopApiDbContext dbContext)
    {
        _paymentRepository = paymentRepository;
        _purchaseRepository = purchaseRepository;
        _booksArchiveRepository = booksArchiveRepository;
        _customerRepository = customerRepository;
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task ExecutePurchase(PurchaseRequestDTO request)
    {
        bool isValidForPurchase = await IsRequestValid(request);
        if (isValidForPurchase)
        {
            throw new ArgumentException("Invalid purchase request");
        }

        var purchase = new Purchase
        {
            BookId = request.BookId,
            CustomerId = request.CustomerId,
            PurchaseDateTime = DateTime.Now
        };


        // Triggers the payment logic
        PaymentService paymentService = new PaymentService(_paymentRepository, _booksArchiveRepository, _dbContext);
        await paymentService.ProcessPayment(purchase);

        //We update the number of books in the archive
        await _booksArchiveRepository.UpdateNumberOfBooks(request);

    }

    public async Task<bool> IsRequestValid(PurchaseRequestDTO request) //to be implemented
    {
        bool doesCustomerExist = await _customerRepository.DoesCustomerExist(request);
        bool isBookAvailable = await _booksArchiveRepository.IsBookAvailable(request.BookId);

        return doesCustomerExist && isBookAvailable;
    }
}