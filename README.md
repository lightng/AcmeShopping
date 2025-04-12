# Acme Shopping Basket Solution

## Overview

This solution simulates a shopping basket where products can be added, removed, and discounted. The `Basket` class is the core of the shopping basket logic, and it interacts with `ProductLine` objects to manage the products in the basket.

### Approach

- **ProductLine Class**: Represents a product in the shopping basket with properties such as `Name`, `Quantity`, `Price`, and `DiscountPercentage`. The class includes methods for applying discounts and calculating the total price based on quantity and discount.
  
- **Basket Class**: Manages the collection of `ProductLine` objects. It allows for adding and removing products, applying discounts to specific products, and calculating the total price of all products in the basket. The `Basket` class relies on the `IProduct` interface for abstracting product details in unit tests, making it easier to mock dependencies.

- **Unit Tests**: NUnit tests have been implemented. Some improvements could be made as some of the basket tests are not true unit tests (they also test product), with further time, I would have mocked these up.

## Solution Structure
- **AcmeShopping.Console** Contains the front-end console application that interacts with the user, allowing them to add, remove, and apply discounts to products in the basket. It also displays the total price of the basket.
- **AcmeShopping.BusinessLogic**: Contains the core business logic, including the `Basket` and `ProductLine` classes.
- **AcmeShopping.BusinessLogic.UnitTests**: Contains unit tests for the business logic, including tests for the `Basket` class using NUnit and Moq.

## How to Run the Solution

1. **Clone the repository** to your local machine:
    ```bash
    git clone https://github.com/lightng/AcmeShopping
    cd acmeshopping
    ```

2. **Restore NuGet packages**:
    This will restore all the necessary dependencies for the solution, including NUnit and Moq.
    ```bash
    dotnet restore
    ```

3. **Build the solution**:
    This will build both the main project and the test project.
    ```bash
    dotnet build
    ```

4. **Run the application**:
    You can run the application by executing:
    ```bash
    dotnet run --project AcmeShopping.Console
    ```

## Running the Tests

To run the tests for the solution, follow these steps:

1. **Navigate to the test project folder**:
    ```bash
    cd AcmeShopping.BusinessLogic.UnitTests
    ```

2. **Run the tests using NUnit**:
    ```bash
    dotnet test
    ```

   This will execute the tests and show the results in the terminal/console. The test framework will run all tests defined in the `BasketTests` class and show you any failures or successes.

## Test Framework

- **NUnit**: A testing framework used for unit testing.
  
## Key Features

- **AddProduct**: Adds a product to the basket.
- **RemoveProduct**: Removes a product from the basket by its ID.
- **ApplyDiscountToProduct**: Applies a discount percentage to a specific product in the basket.
- **GetBasketTotal**: Calculates the total price of all products in the basket, including any discounts.
  