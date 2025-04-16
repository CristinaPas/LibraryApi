using LibraryShopApi.Models.Entities;

namespace LibraryShopApi.Interfaces.Respositories
{
    public interface IPaymentRepository
    {
        DateTime PaymentDateTime { get; set; }
        int PaymentId { get; set; }
        Purchase Purchase { get; set; }
        int PurchaseId { get; set; }
        decimal TotalPrice { get; set; }
    }
}