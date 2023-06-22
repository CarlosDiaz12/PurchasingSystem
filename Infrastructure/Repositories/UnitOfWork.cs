using Application.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext context)
        {
            dbContext = context;
        }

        public async Task Commit() => await dbContext.SaveChangesAsync();

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
