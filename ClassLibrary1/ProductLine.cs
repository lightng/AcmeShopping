namespace AcmeShopping.BusinessLogic;
public class ProductLine : IProductLine
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal DiscountPercentage { get; set; }

    public ProductLine(string name, int quantity, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Quantity = quantity;
        Price = price;
        DiscountPercentage = 0;
    }
    public decimal Total => Price * (100 - DiscountPercentage) / 100 * Quantity;

    public void ApplyDiscount(decimal discountPercentage)
    {
        this.DiscountPercentage = discountPercentage;
    }

    public override string ToString()
    {
        return $"{Id.ToString()} {Name} ({Quantity}) at {Price:C} Discount: {DiscountPercentage} Total Cost: {Total:C}";
    }
}