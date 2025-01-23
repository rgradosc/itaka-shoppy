using System.ComponentModel.DataAnnotations;

namespace ItakaShoppy.Backend.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string? Remarks { get; set; }

        public string? Status { get; set; }

        public virtual IEnumerable<OrderDetail> OrdersDetail { get; set; } = new List<OrderDetail>();
    }
}
