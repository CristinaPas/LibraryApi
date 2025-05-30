using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Interfaces.Respositories;

public interface IPurchaseRepository
{
    public Task AddNewPurchase(Purchase purchaseRequest);
}