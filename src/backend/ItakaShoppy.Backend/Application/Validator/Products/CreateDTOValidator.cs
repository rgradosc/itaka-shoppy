using FluentValidation;
using ItakaShoppy.Backend.Application.DTO.Products;
using System.Data;

namespace ItakaShoppy.Backend.Application.Validator.Products
{
    public class CreateDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateDTOValidator()
        {
            RuleFor(x => x.Descripcion).NotNull().NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
