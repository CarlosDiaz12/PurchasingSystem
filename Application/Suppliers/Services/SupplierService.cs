using Application.Repositories;
using Application.Suppliers.DTOs;
using Application.Suppliers.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Suppliers.Services
{
    public class SupplierService: ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SupplierService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Create(CreateSupplierDTO dto)
        {
            var entity = new Supplier
            {
                IdNumber = dto.IdNumber,
                Name = dto.Name,
            };

            await _unitOfWork.SupplierRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.SupplierRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<List<Supplier>> GetAll()
        {
            return (await _unitOfWork.SupplierRepository
                                    .GetAll())
                                    .ToList();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _unitOfWork.SupplierRepository.Get(x => x.Id == id);
        }

        public async Task Update(UpdateSupplierDTO dto)
        {
            var entity = new Supplier
            {
                Id = dto.Id,
                IdNumber = dto.IdNumber,
                Name = dto.Name,
            };

            _unitOfWork.SupplierRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
