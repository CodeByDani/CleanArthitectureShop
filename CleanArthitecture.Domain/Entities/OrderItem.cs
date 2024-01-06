using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class OrderItem : BaseEntity, IEntityMarker
    {
        public double TotalPrice { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
