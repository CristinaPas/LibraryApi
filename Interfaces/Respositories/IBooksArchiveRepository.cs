using LibraryShopApi.DTOs;

namespace LibraryShopApi.Interfaces.Respositories
{
    public interface IBooksArchiveRepository
    {
        public Task<decimal> GetBookPrice(string name);
        public Task<bool> IsBookAvailable(string name);
        public Task<int> NumberOfBooksInStore(string name);
        public Task UpdateNumberOfBooks(PurchaseRequestDTO request);
    }
}