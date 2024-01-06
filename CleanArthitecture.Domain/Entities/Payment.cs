using CleanArthitecture.Domain.Common;
using CleanArthitecture.Domain.Enums;

namespace CleanArthitecture.Domain.Entities
{
    public class Payment : BaseEntity, IEntityMarker
    {
        public long CustomerID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public Customer Customer { get; set; }
        public long OrderID { get; set; }
        public Order Order { get; set; }
    }
}
