using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using CleanArthitecture.Infrastructure.Persistence.Common.Repository;

namespace CleanArthitecture.Infrastructure.Persistence.Repositories;

public class AddressRepository(DBContextConnection dbContext) :
    GenericRepository<Address>(dbContext), IAddressRepository
{

}