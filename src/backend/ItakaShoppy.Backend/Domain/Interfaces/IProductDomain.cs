using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Domain.Interfaces
{
    public interface IProductDomain
    {
        Task<bool> InsertAsync(Product product);
    }
}
