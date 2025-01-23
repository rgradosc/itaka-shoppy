using System.Data;

namespace ItakaShoppy.Backend.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetDbConnection { get; }
    }
}
