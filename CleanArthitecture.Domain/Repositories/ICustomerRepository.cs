using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Domain.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Delete(Customer customer);
        Task<Customer> FindByIdAsync(long id);
        Task<Customer> FindByEmailAsync(string email);
        Task<List<Customer>> GetAll();

        void Update(Customer customer);
    }
}
