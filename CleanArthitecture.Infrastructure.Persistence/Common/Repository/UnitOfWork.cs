using CleanArthitecture.Application.Common.Interfaces;

namespace CleanArthitecture.Infrastructure.Persistence.Common.Repository
{
    public class UnitOfWork(DBContextConnection dbContext) : IUnitOfWork
    {
        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
