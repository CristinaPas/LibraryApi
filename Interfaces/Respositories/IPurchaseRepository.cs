using LibraryShopApi.DTOs;

namespace LibraryShopApi.Interfaces.Respositories;

public interface IPurchaseRepository
{
    public Task AddNewPurchase(PurchaseRequestDTO purchaseRequest);
}