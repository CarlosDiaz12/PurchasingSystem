using Application.Common.Interfaces;
using Application.Suppliers.DTOs;
using Domain.Entities;

namespace Application.Suppliers.Interfaces
{
    public interface ISupplierService: IService<Supplier, CreateSupplierDTO, UpdateSupplierDTO>
    {
    }
}
