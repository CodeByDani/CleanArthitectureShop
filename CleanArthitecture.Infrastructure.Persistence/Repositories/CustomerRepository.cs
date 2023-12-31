using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using CleanArthitecture.Infrastructure.Persistence.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace CleanArthitecture.Infrastructure.Persistence.Repositories;

public class CustomerRepository(DBContextConnection dbContext) :
    GenericRepository<Customer>(dbContext), ICustomerRepository
{
    public async Task<Customer> FindByEmailAsync(string email)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Email == email);
    }
}

