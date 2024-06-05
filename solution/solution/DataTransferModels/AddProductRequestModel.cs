namespace solution.ResponseModels;

public class AddProductRequestModel
{
    public string productName { get; set; }
    public double productWeight { get; set; }
    public double productWidth { get; set; }
    public double productHeight { get; set; }
    public double productDepth { get; set; }
    public IEnumerable<int> productCategories { get; set; }
}