using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Domain.Repositories;

public interface IProductRepository
{
    void Add(Product product);
    void Delete(Product product);
    Task<Product> FindByIdAsync(long id);
    Task<List<Product>> GetAll();
    Task<List<Product>> GetAllProductByCategoryId(long Id);
    void Update(Product product);
}