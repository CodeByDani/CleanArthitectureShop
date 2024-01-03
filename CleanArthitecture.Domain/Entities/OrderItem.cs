using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public double OldPrice { get; set; }
        public double Discount { get; set; }
        public double NewPrice { get; set; }
        public long ProductID { get; set; }
        private long ProductQuntity { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
