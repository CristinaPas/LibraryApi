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
        public bool AvailabilityFlag { get; private set; }
        public decimal Price { get; set; }

        //public BooksArchive()
        //{
        //    SetFlag();
        //}

        public void SetFlag()
        {
            this.AvailabilityFlag = NumberOfBooks > 0;

        }

        public void UpdateNumberOfBooks(int numberOfBooks)
        {
            this.NumberOfBooks = numberOfBooks;
            SetFlag();
        }
    }
}
