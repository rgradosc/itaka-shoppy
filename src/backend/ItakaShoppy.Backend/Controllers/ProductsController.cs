using ItakaShoppy.Backend.Application.DTO.Products;
using ItakaShoppy.Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItakaShoppy.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductsController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateProductDTO createDTO)
        {
            if (createDTO == null)
            {
                return BadRequest();
            }

            var response = await _productApplication.InsertAsync(createDTO);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

    }
}
