using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using CleanArthitecture.Infrastructure.Persistence.Common.Repository;

namespace CleanArthitecture.Infrastructure.Persistence.Repositories;

public class OrderRepository(DBContextConnection dbContext) :
    GenericRepository<Order>(dbContext), IOrderRepository
{
    public void Add(Order order)
    {
        var result = _dbContext.Orders.AddAsync(order).Result;
    }

    public long ReturnId(Order order)
    {
        return order.Id;
    }

    public Task<Order> FindByUserIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}