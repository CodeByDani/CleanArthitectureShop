using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Domain.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    long ReturnId(Order order);
    Task<Order> FindByIdAsync(long id);
    Task<List<Order>> GetAll();
    Task<Order> FindByUserIdAsync(long id);
    void Update(Order order);
}