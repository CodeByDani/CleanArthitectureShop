using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class Order : BaseEntity, IEntityMarker
    {
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Amount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment> Payment { get; set; }
    }
}
