namespace ItakaShoppy.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Id = 0;
            Name = name;
            Price = price;
            Description = string.Empty;
        }
    }
}
