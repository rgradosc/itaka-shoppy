using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Application.DTO.Orders
{
    public class CreateOrderDTO
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string Remarks { get; set; }

        public IEnumerable<CreateOrderItemDTO> Items { get; set; }

        public Order ToOrder()
        {
            Order order = new Order
            {
                Id = Id,
                OrderDate = DateTime.UtcNow,
                Remarks = Remarks,
                Status = Status
            };

            foreach (var item in Items) 
            {
                OrderDetail detail = item.ToOrderDetail();
                order.OrdersDetail.Append(detail);
            }

            return order;
        }
    }
}
