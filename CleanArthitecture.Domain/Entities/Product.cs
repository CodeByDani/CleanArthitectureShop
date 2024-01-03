using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quntity { get; set; }
        public string Color { get; set; }

        public Category Category { get; set; }
        public long CategoryID { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
