using ItakaShoppy.Backend.Domain.Entity;
using ItakaShoppy.Backend.Domain.Interfaces;
using ItakaShoppy.Backend.Infrastructure.Interfaces;

namespace ItakaShoppy.Backend.Domain.Core
{
    public class ProductDomain : IProductDomain
    {
        private readonly IProductRepository _productRepository;

        public ProductDomain(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }
    }
}
