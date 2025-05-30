namespace LibraryShopApi.DTOs;

public class PurchaseRequestDTO
{
    public string BookName { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public int CustomerId { get; set; }
    public int NumberOfBooksPurchased { get; set; }
    //public Dictionary<int, int> BookIdAndNumberOfBooks { get; set; } = new Dictionary<int, int>();

}
