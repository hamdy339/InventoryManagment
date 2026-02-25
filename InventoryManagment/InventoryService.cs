using System;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class InventoryService
    {
        private Dictionary<int, Product> products = new();
        public void AddProduct(Product product)
        {
            while (products.ContainsKey(product.Id))
            {
                Console.WriteLine("Product with this ID already exists.");
                Console.Write("Enter a different ID: ");
                product.Id = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            products[product.Id] = product;
        }
        public void RemoveProduct(int productId)
        {
            while (!products.ContainsKey(productId))
            {
                Console.WriteLine("Product with this ID does not exist.");
                Console.Write("Enter a valid ID: ");
                productId = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            products.Remove(productId);
            Console.WriteLine("Product removed Successfully!");
        }
        public List<Product> GetAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products in inventory.");
                return new List<Product>();
            }
            return products.Values.ToList();
        }
        public Product GetProductById(int id) { 
        while (!products.ContainsKey(id))
            {
                Console.WriteLine("Product with this ID does not exist.");
                Console.Write("Enter a valid ID: ");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            return products[id];
        }
        public void GetlimitedStock(int threshold)
        {
            string temp = "";
            foreach (var product in products.Values)
            {
                if (product.Stock < threshold) {
                   temp += product.Name.ToString() + " , ";
                }
                    
            }
            Console.WriteLine(temp == "" ? "No product with this stock or less" : temp);

        }
        public void UpdateProductPrice(int id, double newPrice)
        {
            while (!products.ContainsKey(id))
            {
                Console.WriteLine("Product with this ID does not exist.");
                Console.Write("Enter a valid ID: ");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            products[id].UpdatePrice(newPrice);
            Console.WriteLine("Price updated successfully!");
            Console.WriteLine();
        }

    }
}
