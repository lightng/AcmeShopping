namespace AcmeShopping.BusinessLogic.UnitTests;

[TestFixture]
public class ProductLineTests
{
    [Test]
    public void Total_ReturnsCorrectValue_WithDiscount()
    {
        var product = new ProductLine("Gadget", 4, 25.0m);
        product.ApplyDiscount(20); // 20% discount
        var total = product.Total;
        Assert.That(total, Is.EqualTo(80.0m));
    }

    [Test]
    public void ApplyDiscount_UpdatesDiscountPercentage()
    {
        var product = new ProductLine("Thing", 1, 100.0m);
        product.ApplyDiscount(15);
        Assert.That(product.DiscountPercentage, Is.EqualTo(15));
    }
}
