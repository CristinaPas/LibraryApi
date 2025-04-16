//using LibraryShopApi.Data;
//using LibraryShopApi.Models.Entities;
//using static LibraryShopApi.Controllers.LibraryShopController;
//namespace LibraryShopApi.EventHandlers;

//public class PurchaseEventHandler
//{
//    private readonly LibraryShopApiDbContext dbContext;
//    public PurchaseEventHandler(LibraryShopApiDbContext dbContext)
//    {
//        this.dbContext = dbContext;
//    }
//    public async Task HandlePurchase(PurchaseEventArgs sender)
//    {
//        // We send the makePurchase requestt to the database and insert a new row in the Purchase table
//        var purchase = new Purchase
//        {
//            BookId = sender.Book.BookId,
//            CustomerId = sender.Customer.CustomerId,
//            PurchaseDateTime = DateTime.Now
//        };

//        dbContext.Purchases.Add(purchase);
//        //await dbContext.SaveChangesAsync();
//        //purchase.PurchaseId = await dbContext.Purchases
//        //    .Where(p => p.BookId == purchase.BookId && p.CustomerId == purchase.CustomerId)
//        //    .Select(p => p.PurchaseId)
//        //    .FirstOrDefaultAsync();

//        //Same for payment table
//        var payment = new Payment
//        {
//            TotalPrice = sender.Book.Price,
//            Purchase = purchase,
//            PaymentDateTime = DateTime.Now
//        };
//    }
//}
