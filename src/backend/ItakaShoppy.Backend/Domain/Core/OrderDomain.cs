using ItakaShoppy.Backend.Domain.Entity;
using ItakaShoppy.Backend.Domain.Interfaces;
using ItakaShoppy.Backend.Infrastructure.Interfaces;

namespace ItakaShoppy.Backend.Domain.Core
{
    public class OrderDomain : IOrderDomain
    {
        private readonly IOrderRepository _orderRepository;

        public OrderDomain(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<bool> InsertAsync(Order order)
        {
            return await _orderRepository.InsertAsync(order);
        }
    }
}
