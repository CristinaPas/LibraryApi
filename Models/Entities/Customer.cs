using System.ComponentModel.DataAnnotations;

namespace LibraryShopApi.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
    }
}
