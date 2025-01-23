using ItakaShoppy.Backend.Application.DTO.Orders;
using ItakaShoppy.Backend.Application.Interfaces;
using ItakaShoppy.Backend.Common;
using ItakaShoppy.Backend.Domain.Core;
using ItakaShoppy.Backend.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace ItakaShoppy.Backend.Application.Main
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IOrderDomain _orderDomain;
        private readonly IAppLogger<OrderApplication> _logger;

        public OrderApplication(IOrderDomain orderDomain, 
            IAppLogger<OrderApplication> logger)
        {
            _orderDomain = orderDomain;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ViewOrderDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ViewOrderDTO>>();

            try
            {
                var orders = await _orderDomain.GetAllAsync();
                response.Data = ViewOrderDTO.ToViewOrdersDTO(orders);

                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
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

        public async Task<Response<bool>> InsertAsync(CreateOrderDTO createOrderDTO)
        {
            var response = new Response<bool>();

            try
            {
                var order = createOrderDTO.ToOrder();
                response.Data = await _orderDomain.InsertAsync(order);

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
