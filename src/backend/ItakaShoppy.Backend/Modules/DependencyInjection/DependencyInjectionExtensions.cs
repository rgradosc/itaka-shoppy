using ItakaShoppy.Backend.Application.Interfaces;
using ItakaShoppy.Backend.Application.Main;
using ItakaShoppy.Backend.Common;
using ItakaShoppy.Backend.Domain.Core;
using ItakaShoppy.Backend.Domain.Interfaces;
using ItakaShoppy.Backend.Infrastructure.Data;
using ItakaShoppy.Backend.Infrastructure.Interfaces;
using ItakaShoppy.Backend.Infrastructure.Repository;
using ItakaShoppy.Backend.Logging;

namespace ItakaShoppy.Backend.Modules.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddScoped<IProductApplication, ProductApplication>();

            services.AddScoped<IProductDomain, ProductDomain>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderApplication, OrderApplication>();

            services.AddScoped<IOrderDomain, OrderDomain>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
