using System.ComponentModel.DataAnnotations;

namespace LibraryShopApi.Models.Entities
{
    public class BooksArchive
    {
        [Key]

        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int NumberOfBooks { get; set; }
        public decimal Price { get; set; }

    }
}
