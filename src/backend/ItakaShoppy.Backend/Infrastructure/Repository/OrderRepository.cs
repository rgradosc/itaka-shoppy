using Dapper;
using ItakaShoppy.Backend.Common;
using ItakaShoppy.Backend.Domain.Entity;
using ItakaShoppy.Backend.Infrastructure.Interfaces;
using System.Data;

namespace ItakaShoppy.Backend.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public OrderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {

                var orders = await connection.QueryAsync<Order>("OrdersList", commandType: CommandType.StoredProcedure);

                foreach (var order in orders)
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", order.Id);

                    order.OrdersDetail = await connection.QueryAsync<OrderDetail>("OrdersDetailListById", param: p, commandType: CommandType.StoredProcedure);
                }

                return orders;
            }
        }

        public async Task<bool> InsertAsync(Order order)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", order.Id);
                p.Add("@Remarks", order.Remarks);
                p.Add("@OrderDate", order.OrderDate);
                p.Add("@Status", order.Status);

                var result = await connection.ExecuteAsync("OrderInsert", param: p, commandType: CommandType.StoredProcedure);

                if (result > 0)
                {
                    IEnumerable<OrderDetail> lines = order.OrdersDetail.ToList();
                    
                    foreach (var line in lines) 
                    {
                        p = new DynamicParameters();
                        p.Add("@Id", line.Id);
                        p.Add("@OrderId", line.OrderId);
                        p.Add("@ProductId", line.ProductId);
                        p.Add("@Description", line.Description);
                        p.Add("@Price", line.Price);
                        p.Add("@Quantity", line.Quantity);

                        result = await connection.ExecuteAsync("OrderItemInsert", param: p, commandType: CommandType.StoredProcedure);
                    }

                }

                return result > 0;
            }
        }
    }
}
