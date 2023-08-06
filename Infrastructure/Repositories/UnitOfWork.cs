using Application.PurchaseOrders.Interfaces;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext context,
            IBaseRepository<Article> articleRepository,
            IBaseRepository<Brand> brandRepository,
            IBaseRepository<Department> departmentRepository,
            IBaseRepository<MeasurementUnit> measurementUnitRepository,
            IBaseRepository<Supplier> supplierRepository,
            IPurchaseOrderRepository purchaseOrderRepository)
        {
            dbContext = context;
            ArticleRepository = articleRepository;
            BrandRepository = brandRepository;
            DepartmentRepository = departmentRepository;
            MeasurementUnitRepository = measurementUnitRepository;
            SupplierRepository = supplierRepository;
            PurchaseOrderRepository = purchaseOrderRepository;
        }

        public IBaseRepository<Article> ArticleRepository { get; }

        public IBaseRepository<Brand> BrandRepository { get; }

        public IBaseRepository<Department> DepartmentRepository { get; }

        public IBaseRepository<MeasurementUnit> MeasurementUnitRepository { get; }

        public IBaseRepository<Supplier> SupplierRepository { get; }

        public IPurchaseOrderRepository PurchaseOrderRepository { get; }

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
