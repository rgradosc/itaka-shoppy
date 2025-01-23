using ItakaShoppy.Backend.Application.DTO.Orders;
using ItakaShoppy.Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItakaShoppy.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderApplication _orderAppication;

        public OrdersController(IOrderApplication orderApplication)
        {
            _orderAppication = orderApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _orderAppication.GetAllAsync();

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateOrderDTO createDTO)
        {
            if (createDTO == null)
            {
                return BadRequest();
            }

            var response = await _orderAppication.InsertAsync(createDTO);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }
    }
}
