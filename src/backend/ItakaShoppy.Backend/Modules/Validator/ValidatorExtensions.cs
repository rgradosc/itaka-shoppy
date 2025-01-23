using ItakaShoppy.Backend.Application.Validator.Products;

namespace ItakaShoppy.Backend.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<CreateDTOValidator>();
            return services;
        }
    }
}
