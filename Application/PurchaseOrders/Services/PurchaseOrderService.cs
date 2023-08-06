using Application.PurchaseOrders.DTOs;
using Application.PurchaseOrders.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PurchaseOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(CreatePurchaseOrderDto dto)
        {
            var entity = new PurchaseOrder
            {
                OrderNumber = dto.OrderNumber,
                Date = dto.Date,
                ArticleId = dto.ArticleId,
                SupplierId = dto.SupplierId,
                Quantity = dto.Quantity,
                DepartmentId = dto.DepartmentId,
                UnitCost = dto.UnitCost,
                Total = dto.Total
            };

            await _unitOfWork.PurchaseOrderRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.PurchaseOrderRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<List<PurchaseOrder>> GetAll()
        {
            return (await _unitOfWork.PurchaseOrderRepository
                        .GetAll())
                        .ToList();
        }

        public async Task<PurchaseOrder> GetById(int id)
        {
            return await _unitOfWork.PurchaseOrderRepository.Get(x => x.Id == id);
        }

        public async Task Update(UpdatePurchaseOrderDto dto)
        {
            var entity = new PurchaseOrder
            {
                Id = dto.Id,
                OrderNumber = dto.OrderNumber,
                Date = dto.Date,
                ArticleId = dto.ArticleId,
                SupplierId = dto.SupplierId,
                Quantity = dto.Quantity,
                DepartmentId = dto.DepartmentId,
                UnitCost = dto.UnitCost,
                Total = dto.Total
            };

            _unitOfWork.PurchaseOrderRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
