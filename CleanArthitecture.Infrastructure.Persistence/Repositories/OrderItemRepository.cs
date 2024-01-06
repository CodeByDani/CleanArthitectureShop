using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;

namespace CleanArthitecture.Infrastructure.Persistence.Repositories;

public class OrderItemRepository(DBContextConnection dbContext) : IOrderItemRepository
{
    protected DBContextConnection _dbContext = dbContext;

    public void AddRange(List<OrderItem> orderItems)
    {
        _dbContext.OrderDetails.AddRangeAsync(orderItems);
    }
}