using ItakaShoppy.Backend.Application.DTO.Products;
using ItakaShoppy.Backend.Application.Interfaces;
using ItakaShoppy.Backend.Common;
using ItakaShoppy.Backend.Domain.Interfaces;

namespace ItakaShoppy.Backend.Application.Main
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductDomain _productDomain;
        private readonly IAppLogger<ProductApplication> _logger;

        public ProductApplication(IProductDomain productDomain,
            IAppLogger<ProductApplication> logger)
        {
            _productDomain = productDomain;
            _logger = logger;
        }

        public async Task<Response<bool>> InsertAsync(CreateProductDTO createDTO)
        {
            var response = new Response<bool>();

            try
            {
                var product = createDTO.ToProduct();
                response.Data = await _productDomain.InsertAsync(product);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(response.Message);
            }

            return response;
        }
    }
}
