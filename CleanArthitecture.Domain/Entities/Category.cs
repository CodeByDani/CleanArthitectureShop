using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set;}

    }
}
