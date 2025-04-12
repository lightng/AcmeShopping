namespace AcmeShopping.BusinessLogic;

public interface IBasket
{
    void AddProduct(ProductLine product);
    void RemoveProduct(Guid id);
    void ApplyDiscountToProduct(Guid id, decimal discountPercentage);
}
