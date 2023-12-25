using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class OrderItem:BaseEntity
    {
        public double Price { get; set; }
        public double Discount { get; set; }
        public long ProductID { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
