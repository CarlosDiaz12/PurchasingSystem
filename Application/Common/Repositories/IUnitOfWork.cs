﻿using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IBaseRepository<Article> ArticleRepository { get; }
        IBaseRepository<Brand> BrandRepository { get; }
        IBaseRepository<Department> DepartmentRepository { get; }
        IBaseRepository<MeasurementUnit> MeasurementUnitRepository { get; }
        IBaseRepository<Supplier> SupplierRepository { get; }
        IBaseRepository<PurchaseOrder> PurchaseOrderRepository { get; }
        Task Commit();
    }
}
