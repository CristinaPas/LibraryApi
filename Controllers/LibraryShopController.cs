using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryShopApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LibraryShopController : ControllerBase
{
    private LibraryShopApiDbContext _dbContext;
    private readonly PurchaseService _purchaseService;
    private readonly PaymentService _paymentService;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IBooksArchiveRepository _booksArchiveRepository;

    public LibraryShopController(LibraryShopApiDbContext dbContext, PurchaseService purchaseService, PaymentService paymentService,
        IPaymentRepository paymentRepository, IPurchaseRepository purchaseRepository, IBooksArchiveRepository booksArchiveRepository)
    {
        _dbContext = dbContext;
        _paymentRepository = paymentRepository;
        _purchaseRepository = purchaseRepository;
        _booksArchiveRepository = booksArchiveRepository;
        _purchaseService = purchaseService;
    }

    [HttpGet("price/{id}")] //put this in booksarchive repo
    public async Task<IActionResult> CheckBookPrice(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        var isBookInShop = await _booksArchiveRepository.IsBookAvailable(name);

        if (!(isBookInShop))
        {
            return NotFound("Book not found.");
        }

        var price = await _booksArchiveRepository.GetBookPrice(name);
        return Ok($"The price of the book '{name}' is {price}.");
    }

    [HttpGet("availability/{id}")]
    public async Task<IActionResult> CheckAvailabilityInStore(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException(name);
        }

        bool availability = await _booksArchiveRepository.IsBookAvailable(name);

        if (!(availability))
        {
            return NotFound("This book is not present in our shop.");
        }
        if (availability)
        {
            return Ok($"The book '{name}' is still available, with {_booksArchiveRepository.NumberOfBooksInStore} number of copies.");
        }
        else return NotFound("The book isn't avaialble in the store");
    }

    [HttpPost("registerCustomer/")]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {

        if (customer != null)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return Ok($"Registration successful");
        }
        else return BadRequest("Invalid customer data.");
    }

    [HttpPost("makePurchase/")]
    public async Task<IActionResult> MakePurchase([FromBody] PurchaseRequestDTO request)
    {
        if (request != null)
        {
            bool doesCostumerExist = await _dbContext.Customers.SingleOrDefaultAsync(c => c.Email == request.Email && c.FullName == request.FullName) != null;
            bool doesBookExist = await _dbContext.BooksArchives.SingleOrDefaultAsync(b => b.BookId == request.BookId) != null;

            if (doesCostumerExist && doesBookExist)
            {
                //trigger the purchase service
                var myPurchaseService = new PurchaseService(_paymentRepository, _purchaseRepository);
                var myPaymentService = new PaymentService(_paymentRepository);
                await myPurchaseService.ExecutePurchase(request);

                return Ok("Purchase successful");
            }
            else
            {
                return NotFound("Customer or book not found.");
            }

        }
        else
        {
            return BadRequest("Invalid purchase data.");
        }
    }

}

