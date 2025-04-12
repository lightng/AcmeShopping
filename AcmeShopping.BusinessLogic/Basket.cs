namespace AcmeShopping.BusinessLogic;

public class Basket : IBasket
{
    public List<ProductLine> Products { get; set; } = new List<ProductLine>();

    public void AddProduct(ProductLine product)
    {
        Products.Add(product);
    }

    public void RemoveProduct(Guid id)
    {
        Products.RemoveAll(p => p.Id == id);
    }

    public void ApplyDiscountToProduct(Guid id, decimal discount)
    {
        var productToUpdate = Products.SingleOrDefault(p => p.Id == id);

        if (productToUpdate != null)
        {
            productToUpdate.ApplyDiscount(discount);
        }
    }

    public decimal GetBasketTotal() => Products.Sum(p => p.Total);

    public override string ToString()
    {
        if (!Products.Any())
        {
            return "Basket is empty.";
        }

        return string.Join("\n", Products.Select(p => $"{p.ToString()}")) + $"\nTotal (including discount): {GetBasketTotal():C}";
    }
}
