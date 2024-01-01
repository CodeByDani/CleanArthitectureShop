using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Domain.Repositories;

public interface IAddressRepository
{
    void Add(Address address);
    void Delete(Address address);
    Task<Address> FindByIdAsync(long id);
    Task<List<Address>> GetAll();

    void Update(Address address);
}