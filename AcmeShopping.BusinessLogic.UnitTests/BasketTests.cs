namespace AcmeShopping.BusinessLogic.UnitTests;

[TestFixture]
public class BasketTests
{
    [Test]
    public void AddProduct_AddsProductToBasket()
    {
        var basket = new Basket();
        var product = new ProductLine("Gadget", 2, 50.0m);

        basket.AddProduct(product);

        Assert.That(basket.Products, Has.Count.EqualTo(1));
        Assert.That(basket.Products[0].Name, Is.EqualTo("Gadget"));
        Assert.That(basket.Products[0].Quantity, Is.EqualTo(2));
    }

    [Test]
    public void RemoveProduct_RemovesProductFromBasket()
    {
        var basket = new Basket();
        var product = new ProductLine("Gadget", 2, 50.0m);
        basket.AddProduct(product);
        var productId = product.Id;

        basket.RemoveProduct(productId);

        Assert.That(basket.Products, Has.Count.EqualTo(0));
    }

    [Test]
    public void ApplyDiscountToProduct_AppliesDiscountCorrectly()
    {
        var basket = new Basket();
        var product = new ProductLine("Gadget", 2, 50.0m);
        basket.AddProduct(product);
        var productId = product.Id;

        basket.ApplyDiscountToProduct(productId, 20); // 20% discount

        Assert.That(basket.Products[0].DiscountPercentage, Is.EqualTo(20));
        Assert.That(basket.Products[0].Total, Is.EqualTo(80.0m)); // 50 * 0.8 * 2 = 80.00
    }

    [Test]
    public void GetBasketTotal_ReturnsCorrectTotal()
    {
        var basket = new Basket();
        var product1 = new ProductLine("Item1", 2, 25.0m);
        var product2 = new ProductLine("Item2", 1, 100.0m);
        basket.AddProduct(product1);
        basket.AddProduct(product2);

        var total = basket.GetBasketTotal();

        Assert.That(total, Is.EqualTo(150.0m));
    }
}
