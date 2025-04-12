using AcmeShopping.BusinessLogic;

bool isRunning = true;
var basket = new Basket();

Console.CancelKeyPress += (sender, e) =>
{
    Console.WriteLine("\nExiting ...");
    isRunning = false;
    e.Cancel = true;
};

Console.WriteLine("Welcome to the Acme Shopping Basket App!");
Console.WriteLine("Use Ctrl+C at any time to exit.\n");

while (isRunning)
{
    Console.WriteLine("\nChoose an action:");
    Console.WriteLine("1 - Add item");
    Console.WriteLine("2 - Remove item");
    Console.WriteLine("3 - Apply DiscountView basket");
    Console.WriteLine("4 - View basket");
    Console.WriteLine("5 - Exit");
    Console.Write("Your choice: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddItem(basket);
            break;
        case "2":
            RemoveItem(basket);
            break;
        case "3":
            ApplyDiscountToProductInConsole(basket);
            break;
        case "4":
            ViewBasket(basket);
            break;
        case "5":
            Exit();
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void AddItem(Basket basket)
{
    Console.Write("Enter product name: ");
    string name = Console.ReadLine() ?? string.Empty;

    Console.Write("Enter quantity: ");
    if (!int.TryParse(Console.ReadLine(), out int quantity))
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    Console.Write("Enter price: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        Console.WriteLine("Invalid price.");
        return;
    }

    var product = new ProductLine(name, quantity, price);
    basket.AddProduct(product);
    Console.WriteLine($"Added: {product.Name} x{product.Quantity} at £{product.Price} each");
}

void RemoveItem(Basket basket)
{
    if (!basket.Products.Any())
    {
        Console.WriteLine("Basket is empty.");
        return;
    }

    Console.WriteLine("Items in basket:");
    foreach (var p in basket.Products)
    {
        Console.WriteLine($"{p.Id} - {p.Name} x{p.Quantity} at £{p.Price}");
    }

    Console.Write("Enter the product ID to remove: ");
    if (!Guid.TryParse(Console.ReadLine(), out Guid id))
    {
        Console.WriteLine("Invalid ID format.");
        return;
    }

    basket.RemoveProduct(id);
    Console.WriteLine("Product removed (if it existed).");
}

void ViewBasket(Basket basket)
{
    Console.WriteLine($"\n{basket.ToString()}");
}

void ApplyDiscountToProductInConsole(Basket basket)
{
    if (!basket.Products.Any())
    {
        Console.WriteLine("Basket is empty. Nothing to discount.");
        return;
    }

    Console.WriteLine("Products in basket:");
    foreach (var product in basket.Products)
    {
        Console.WriteLine($"{product.Id} - {product.Name} x{product.Quantity} at £{product.Price:F2} each (Total: £{product.Total:F2})");
    }

    Console.Write("Enter the product ID to apply a discount to: ");
    if (!Guid.TryParse(Console.ReadLine(), out Guid productId))
    {
        Console.WriteLine("Invalid product ID format.");
        return;
    }

    Console.Write("Enter discount percentage: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal discount) || discount <= 0)
    {
        Console.WriteLine("Invalid discount value.");
        return;
    }

    basket.ApplyDiscountToProduct(productId, discount);
    Console.WriteLine("Discount applied (if product was found).");
}

void Exit()
{
    Console.WriteLine("Exiting ...");
    isRunning = false;
}