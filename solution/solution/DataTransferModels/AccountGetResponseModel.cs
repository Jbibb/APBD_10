namespace solution.ResponseModels;

public class AccountGetResponseModel
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string? phone { get; set; }
    public string role { get; set; }
    public IEnumerable<CartElementResponseModel> cart { get; set; }
}

public class CartElementResponseModel
{
    public int productId { get; set; }
    public string productName { get; set; }
    public int amount { get; set; }
}