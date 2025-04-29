using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Interfaces.Respositories
{
    public interface IPaymentRepository
    {
        public Task AddPaymentIntoTable(Payment payment); //example of task to be implemented

    }
}