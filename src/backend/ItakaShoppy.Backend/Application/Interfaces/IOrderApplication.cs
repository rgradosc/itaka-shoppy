using ItakaShoppy.Backend.Application.DTO.Orders;
using ItakaShoppy.Backend.Common;

namespace ItakaShoppy.Backend.Application.Interfaces
{
    public interface IOrderApplication
    {
        Task<Response<bool>> InsertAsync(CreateOrderDTO createOrderDTO);

        Task<Response<IEnumerable<ViewOrderDTO>>> GetAllAsync();
    }
}
