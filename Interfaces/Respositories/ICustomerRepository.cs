namespace LibraryShopApi.Interfaces.Respositories
{
    public interface ICustomerRepository
    {
        int CustomerId { get; set; }
        string Email { get; set; }
        string FullName { get; set; }
    }
}