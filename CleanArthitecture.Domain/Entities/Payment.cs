using CleanArthitecture.Domain.Common;
using CleanArthitecture.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArthitecture.Domain.Entities
{
    public class Payment:BaseEntity
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
