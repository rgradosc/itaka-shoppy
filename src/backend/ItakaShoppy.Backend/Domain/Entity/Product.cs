namespace ItakaShoppy.Backend.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public float Stock { get; set; }

        public ICollection<OrderDetail> OrdersDetail { get; set; }
    }
}
