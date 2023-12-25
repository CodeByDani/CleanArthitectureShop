using CleanArthitecture.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArthitecture.Domain.Entities
{
    public class Order:BaseEntity
    {
        public long CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PickupDate { get; set; }
        public double Amount { get; set; }
        public double AmountDiscount { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}
