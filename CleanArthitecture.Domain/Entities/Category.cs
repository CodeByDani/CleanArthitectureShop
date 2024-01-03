using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class Category : BaseEntity, IEntityMarker
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
