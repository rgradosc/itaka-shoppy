using ItakaShoppy.Backend.Application.DTO.Products;
using ItakaShoppy.Backend.Common;

namespace ItakaShoppy.Backend.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<Response<bool>> InsertAsync(CreateProductDTO createDTO);
    }
}
