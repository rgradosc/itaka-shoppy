using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Application.DTO.Orders
{
    public class ViewOrderDTO
    {
        public string Status { get; set; }

        public string Remarks { get; set; }

        public string Date { get; set; }

        public IEnumerable<ViewOrderItemDTO> Items { get; set; }

        public static IEnumerable<ViewOrderDTO> ToViewOrdersDTO(IEnumerable<Order> orders)
        {
            ICollection<ViewOrderDTO> viewOrderDTOs = new List<ViewOrderDTO>();

            foreach (var order in orders) 
            {
                var orderDTO = new ViewOrderDTO
                {
                    Date = order.OrderDate.ToShortDateString(),
                    Remarks = order.Remarks,
                    Status = order.Status,
                    Items = ViewOrderItemDTO.ToViewOrderItemsDTO(order.OrdersDetail)
                };
                viewOrderDTOs.Add(orderDTO);
            }

            return viewOrderDTOs;
        }
    }
}
