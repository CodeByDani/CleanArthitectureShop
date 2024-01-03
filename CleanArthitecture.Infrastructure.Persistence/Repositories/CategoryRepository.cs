using CleanArthitecture.Domain.Entities;
using CleanArthitecture.Domain.Repositories;
using CleanArthitecture.Infrastructure.Persistence.Common.Repository;

namespace CleanArthitecture.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository(DBContextConnection dbContext) :
        GenericRepository<Category>(dbContext), ICategoryRepository
    {

    }
}
