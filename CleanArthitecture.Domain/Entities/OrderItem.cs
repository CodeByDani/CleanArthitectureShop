using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        private long Quntity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
