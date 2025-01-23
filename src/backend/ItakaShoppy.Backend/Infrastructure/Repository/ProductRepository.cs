using Dapper;
using ItakaShoppy.Backend.Common;
using ItakaShoppy.Backend.Domain.Entity;
using ItakaShoppy.Backend.Infrastructure.Interfaces;
using System.Data;

namespace ItakaShoppy.Backend.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            using (var connection = _connectionFactory.GetDbConnection)
            {
                var p = new DynamicParameters();
                p.Add("@Id", product.Id);
                p.Add("@Description", product.Description);
                p.Add("@Price", product.Price);
                p.Add("@Stock", product.Stock);

                var result = await connection.ExecuteAsync("ProductInsert", param: p, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}
