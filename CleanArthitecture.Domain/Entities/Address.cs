using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class Address : BaseEntity, IEntityMarker
    {

        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Details { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
