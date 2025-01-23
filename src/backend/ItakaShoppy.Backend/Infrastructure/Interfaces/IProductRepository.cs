using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> InsertAsync(Product product);
    }
}
