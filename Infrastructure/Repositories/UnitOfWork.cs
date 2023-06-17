using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
