using CleanArthitecture.Domain.Entities;

namespace CleanArthitecture.Domain.Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Delete(Category category);
        Task<Category> FindByIdAsync(long id);
        Task<List<Category>> GetAll();

        void Update(Category category);
    }
}
