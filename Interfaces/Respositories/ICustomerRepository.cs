using LibraryShopApi.DTOs;
using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Interfaces.Respositories
{
    public interface ICustomerRepository
    {
        public Task AddCustomerIntoTable(Customer customer); //example of task to be implemented
        public Task<bool> DoesCustomerExist(PurchaseRequestDTO request); //example of task to be implemented
    }
}