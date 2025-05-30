using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Interfaces.Services;

public interface IPaymentService
{
    public Task ProcessPayment(Purchase purchase);
}
