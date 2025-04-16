using LibraryShopApi.Data;
using LibraryShopApi.DTOs;
using LibraryShopApi.Models.Entities;
using LibraryShopApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryShopApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LibraryShopController : ControllerBase
{
    private LibraryShopApiDbContext dbContext;
    private readonly PurchaseService purchaseService;
    private readonly PaymentService paymentService;

    public LibraryShopController(LibraryShopApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet("price/{id}")]
    public async Task<IActionResult> GetBookPrice(int id)
    {
        var book = await dbContext.BooksArchives.FirstOrDefaultAsync(b => b.BookId == id);

        if (book == null)
        {
            return NotFound("Book not found.");
        }
        return Ok($"The price of the book '{book.Name}' is {book.Price}.");
    }

    [HttpGet("availability/{id}")]
    public async Task<IActionResult> IsBookAvailable(int id)
    {
        var book = await dbContext.BooksArchives.FirstOrDefaultAsync(b => b.BookId == id);

        if (book != null)
        {
            return Ok($"The book '{book.Name}' is still available, with {book.NumberOfBooks} number of copies.");
        }
        else return NotFound("The book isn't avaialble in the store");
    }

    [HttpPost("setAvailabilityFlag/")]
    public async Task<IActionResult> SetFlag()
    {
        var books = await dbContext.BooksArchives.Where(b => b.NumberOfBooks > 0).ToListAsync();

        if (books != null)
        {
            books.ForEach(b => b.SetFlag());
            await dbContext.SaveChangesAsync();
            return Ok($"Availability Flag has been set");
        }
        else return NotFound("The book isn't avaialble in the store");
    }

    [HttpPost("registerCustomer/")]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
    {

        if (customer != null)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            return Ok($"Registration successful");
        }
        else return BadRequest("Invalid customer data.");
    }

    [HttpPost("makePurchase/")]
    public async Task<IActionResult> MakePurchase([FromBody] PurchaseRequest request)
    {
        if (request != null)
        {
            bool doesCostumerExist = await dbContext.Customers.SingleOrDefaultAsync(c => c.Email == request.Email && c.FullName == request.FullName) != null;
            bool doesBookExist = await dbContext.BooksArchives.SingleOrDefaultAsync(b => b.BookId == request.BookId) != null;

            if (doesCostumerExist && doesBookExist)
            {
                //trigger the purchase service
                var myPurchaseService = new PurchaseService(dbContext);
                var myPaymentService = new PaymentService(dbContext, purchaseService);
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

