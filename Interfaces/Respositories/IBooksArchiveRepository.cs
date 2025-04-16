namespace LibraryShopApi.Interfaces.Respositories
{
    public interface IBooksArchiveRepository
    {
        string Author { get; set; }
        bool AvailabilityFlag { get; }
        int BookId { get; set; }
        string Name { get; set; }
        int NumberOfBooks { get; set; }
        decimal Price { get; set; }

        void SetFlag();
        void UpdateNumberOfBooks(int numberOfBooks);
    }
}