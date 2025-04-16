using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Interfaces.Respositories;

public interface IPurchaseRepository
{
    Task<Purchase> GetPurchaseByIdAsync(int id);
}