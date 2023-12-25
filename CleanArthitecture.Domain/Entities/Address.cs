using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class Address:BaseEntity
    {

        public  string City { get; set; }
        public  string Region { get; set; }
        public  string FullAddress { get; set; }
        public  string PostalCode { get; set; }
        public  string Details { get; set; }
        public Customer Customer { get; set; }

    }
}
