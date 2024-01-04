using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using CleanArthitecture.Infrastructure.Persistence.Common.Repository;
using Microsoft.EntityFrameworkCore;

namespace CleanArthitecture.Infrastructure.Persistence.Repositories;

public class ProductRepository(DBContextConnection dbContext) :
    GenericRepository<Product>(dbContext), IProductRepository
{
    public async Task<List<Product>> GetAllProductByCategoryId(long Id)
    {
        var products = await _dbContext.Products
            .Where(p => p.CategoryId == Id)
            .ToListAsync();
        return products;
    }
}