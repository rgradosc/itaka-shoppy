using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Application.DTO.Orders
{
    public class CreateOrderItemDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public float Quantity { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }


        public OrderDetail ToOrderDetail()
        {
            return new OrderDetail
            {
                Id = Id,
                OrderId = OrderId,
                ProductId = ProductId,
                Price = Price,
                Quantity = Quantity,
                Description = Description
            };
        }

    }
}
