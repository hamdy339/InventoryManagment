using System;
using InventoryManagement.Models;
using InventoryManagement.Services;

var inventory = new InventoryService();

while (true)
{
    Console.WriteLine("\n1. Add Product");
    Console.WriteLine("2. Remove Product");
    Console.WriteLine("3. Show All Products");
    Console.WriteLine("4. Show Product by ID");
    Console.WriteLine("5. Show Products by Stock");
    Console.WriteLine("6. Update Product Price");
    Console.WriteLine("7. Update a Product Stock");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1": //add product
            int id;
            while (true)
            {
                Console.Write("ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                    break;

                Console.WriteLine("Invalid ID. Please enter a positive number.");
            }

            Console.Write("Name: ");
            string name = Console.ReadLine();

            double price;
            while (true)
            {
                Console.Write("Price: ");
                if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                    break;

                Console.WriteLine("Invalid price. Enter a valid number.");
            }

            int stock;
            while (true)
            {
                Console.Write("Stock: ");
                if (int.TryParse(Console.ReadLine(), out stock) && stock >= 0)
                    break;

                Console.WriteLine("Invalid stock. Enter a valid number.");
            }

            var product = new Product(id, name, price, stock);
            inventory.AddProduct(product);

            Console.WriteLine("Product added!");
            break;


        case "2": //remove product
          Console.Write("Enter Product ID to remove: ");
            int removeId = int.Parse(Console.ReadLine());
            inventory.RemoveProduct(removeId);
            break;


        case "3"://show all
            var products = inventory.GetAllProducts();
            foreach (var p in products)
                Console.WriteLine(p);
            break;


        case "4"://show one by ID
            Console.Write("Enter Product ID: ");
            int searchId = int.Parse(Console.ReadLine());
            var foundProduct = inventory.GetProductById(searchId);
            Console.WriteLine(foundProduct);
            break;


        case "5"://search for a limited stock
            Console.Write("Enter Stock Threshold: ");
            int threshold = int.Parse(Console.ReadLine());
            inventory.GetlimitedStock(threshold);
            break;


        case "6"://edit price
            Console.Write("Enter Product ID: ");
            int updateId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Price: ");
            double newPrice = double.Parse(Console.ReadLine());
            inventory.UpdateProductPrice(updateId, newPrice);
            break;


        case "7"://edit stock
            Console.Write("Enter Product ID: ");
            int stockId = int.Parse(Console.ReadLine());
            var stockProduct = inventory.GetProductById(stockId);
            Console.Write("Enter 'I' to Increase or 'D' to Decrease: ");
            string action = Console.ReadLine().ToUpper();
            if (action == "D")
            {
                Console.Write("Enter Quantity to Decrease: ");
                int quantity = int.Parse(Console.ReadLine());
                stockProduct.DecreaseStock(quantity);
            }
            else if (action == "I")
            {
                Console.Write("Enter Quantity to Increase: ");
                int quantity = int.Parse(Console.ReadLine());
                stockProduct.IncreaseStock(quantity);
            }
            else {Console.WriteLine("Invalid choice. Please enter 'I' or 'D'."); }
                Console.WriteLine("Stock updated!");
            break;


        case "0":
            Console.WriteLine("Exiting...");
            return;


        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;

    }
}