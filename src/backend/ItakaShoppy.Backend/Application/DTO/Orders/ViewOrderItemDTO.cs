using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Application.DTO.Orders
{
    public class ViewOrderItemDTO
    {
        public string Product{ get; set; }

        public float Stock { get; set; }

        public decimal Total { get; set; }


        public static IEnumerable<ViewOrderItemDTO> ToViewOrderItemsDTO(IEnumerable<OrderDetail> orderDetails)
        {
            ICollection<ViewOrderItemDTO> itemsDTO = new List<ViewOrderItemDTO>();

            foreach (var orderDetail in orderDetails)
            {
                var itemDTO = new ViewOrderItemDTO
                {
                    Product = orderDetail.Product.Description,
                    Stock = orderDetail.Quantity,
                    Total = (decimal)orderDetail.Quantity * orderDetail.Price
                };
                itemsDTO.Add(itemDTO);
            }

            return itemsDTO;
        }

    }
}
