using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Interfaces.Services;
using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Services;

public class PurchaseService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IBooksArchiveRepository _booksArchiveRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IPaymentService _paymentService;
    private readonly LibraryShopApiDbContext _dbContext;

    public PurchaseService(
        IPaymentRepository paymentRepository,
        IPurchaseRepository purchaseRepository,
        IBooksArchiveRepository booksArchiveRepository,
        ICustomerRepository customerRepository,
        IPaymentService paymentService,
        LibraryShopApiDbContext dbContext)
    {
        _paymentRepository = paymentRepository;
        _purchaseRepository = purchaseRepository;
        _booksArchiveRepository = booksArchiveRepository;
        _customerRepository = customerRepository;
        _paymentService = paymentService;
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<string> ExecutePurchase(PurchaseRequestDTO request)
    {
        bool isValidForPurchase = await IsRequestValid(request);

        if (!(isValidForPurchase))
        {
            return "Invalid purchase request: the customer doesn't exist or the request isn't valid";
        }

        var purchase = new Purchase
        {
            BookId = await _booksArchiveRepository.GetBookIdByName(request.BookName),
            CustomerId = request.CustomerId,
            PurchaseDateTime = DateTime.Now
        };


        // Triggers the payment logic
        _paymentService.ProcessPayment(purchase);

        //We update the number of books in the archive
        await _booksArchiveRepository.UpdateNumberOfBooks(request);
        await _purchaseRepository.AddNewPurchase(purchase);

        return "Completed";

    }

    public async Task<bool> IsRequestValid(PurchaseRequestDTO request)
    {
        bool doesCustomerExist = await _customerRepository.DoesCustomerExist(request);
        bool isBookAvailable = await _booksArchiveRepository.IsBookAvailable(request.BookName);

        return doesCustomerExist && isBookAvailable;
    }
}