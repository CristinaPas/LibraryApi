using LibraryShopApi.DTOs;

namespace LibraryShopApi.Interfaces.Respositories
{
    public interface IBooksArchiveRepository
    {
        Task<int> GetBookIdByName(string bookName);
        public Task<decimal> GetBookPriceByName(string name);
        public Task<decimal> GetBookPriceById(int id);
        public Task<bool> IsBookAvailable(string name);
        public Task<bool> IsBookAvailableForPurchase(PurchaseRequestDTO request);
        public Task<int> NumberOfBooksInStore(string name);
        public Task UpdateNumberOfBooks(PurchaseRequestDTO request);
    }
}