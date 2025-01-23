using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Domain.Interfaces
{
    public interface IOrderDomain
    {
        Task<bool> InsertAsync(Order order);

        Task<IEnumerable<Order>> GetAllAsync();
    }
}
