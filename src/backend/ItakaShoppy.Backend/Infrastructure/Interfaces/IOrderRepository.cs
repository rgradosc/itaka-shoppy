using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Infrastructure.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> InsertAsync(Order order);

        Task<IEnumerable<Order>> GetAllAsync();
    }
}
