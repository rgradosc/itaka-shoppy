using ItakaShoppy.Backend.Domain.Entity;

namespace ItakaShoppy.Backend.Application.DTO.Products
{
    public class CreateProductDTO
    {
        public string Descripcion { get; set; }

        public decimal Price { get; set; }

        public float Stock { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Description = Descripcion,
                Price = Price,
                Stock = Stock
            };
        }
    }
}
