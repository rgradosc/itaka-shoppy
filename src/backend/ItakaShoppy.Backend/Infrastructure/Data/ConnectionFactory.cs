using ItakaShoppy.Backend.Common;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ItakaShoppy.Backend.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetDbConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection != null) { return null; }
                sqlConnection.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
