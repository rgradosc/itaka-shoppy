using ItakaShoppy.Shared.Entities;

namespace ItakaShoppy.Shared.DTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Product ToProduct()
        {
            return new Product(Name, Price)
            {
                Description = Description,
            };
        }
    }
}
