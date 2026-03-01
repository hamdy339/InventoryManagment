namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Stock;

        public Product(int id, string name, double price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}, Stock: {Stock}";
        }
        public void IncreaseStock(int quantity)
        {
            Stock += quantity;
        }
        public void DecreaseStock(int quantity)
        {
            while (quantity > Stock)
            {
                Console.WriteLine($"Not enough stock. Current stock: {Stock}");
                Console.Write("Enter a smaller quantity: ");
                quantity = int.Parse(Console.ReadLine());
            }
            Stock -= quantity;
        }
        public void UpdatePrice(double price)
        {
            Price = price;
        }
       
        }
}