using System.ComponentModel.DataAnnotations;

namespace LibraryShopApi.Models.Entities
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public int BookId { get; set; }
        public BooksArchive Book { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
