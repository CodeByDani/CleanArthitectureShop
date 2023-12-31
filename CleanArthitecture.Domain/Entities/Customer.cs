using CleanArthitecture.Domain.Common;

namespace CleanArthitecture.Domain.Entities
{
    public class Customer : BaseEntity, IEntityMarker
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public string Password { get; set; }
        public long AddressId { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> payments { get; set; }


        public ICollection<Address>? Addresses { get; set; }


    }
}
