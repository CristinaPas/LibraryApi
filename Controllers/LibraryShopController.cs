using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Interfaces.Respositories;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("price/{id}")]
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

        var price = await _booksArchiveRepository.GetBookPriceByName(name);
        return Ok($"The price of the book '{name}' is {price}.");
    }

    [HttpGet("availability/{id}")]
    public async Task<IActionResult> CheckAvailabilityInStore(string bookName)
    {
        if (bookName == null)
        {
            throw new ArgumentNullException(bookName);
        }

        bool availability = await _booksArchiveRepository.IsBookAvailable(bookName);

        if (!(availability))
        {
            return NotFound("The book isn't avaialble in the store");
        }
        return Ok($"The book '{bookName}' is still available, with {_booksArchiveRepository.NumberOfBooksInStore} number of copies.");
    }

    [HttpPost("registerCustomer/")] //move this to Customer Repository
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
            //trigger the purchase service
            string isPurchaseExecuted = await _purchaseService.ExecutePurchase(request);

            if (isPurchaseExecuted != null)
            {

                return Ok("Purchase successful");
            }
            else
            {
                return BadRequest("Purchase failed.");
            }
        }

        else
        {
            return NotFound("The request is null and invalid");
        }

    }

}

