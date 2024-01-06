using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Domain.Repositories;

public interface IOrderItemRepository
{
    void AddRange(List<OrderItem> orderItems);

}