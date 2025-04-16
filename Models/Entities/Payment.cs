using System.ComponentModel.DataAnnotations;

namespace LibraryShopApi.Models.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
