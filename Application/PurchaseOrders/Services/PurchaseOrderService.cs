using Application.Common.Exceptions;
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

        private async Task UpdateArticleStock(int articleId, int quantity)
        {
            var article = await _unitOfWork.ArticleRepository.Get(x => x.Id == articleId) ?? throw new BusinessException("Articulo no encontrado.");
            article.Stock += quantity;
        }

        private async Task<bool> ArticleExists(int articleId)
        {
            var data = await _unitOfWork.ArticleRepository.Get(x => x.Id == articleId);
            return data != null;
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

            await UpdateArticleStock(dto.ArticleId, dto.Quantity);

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
            string includeProps = $"{nameof(PurchaseOrder.Article)}," +
                $"{nameof(PurchaseOrder.Department)}," +
                $"{nameof(PurchaseOrder.Supplier)}";
            return (await _unitOfWork.PurchaseOrderRepository
                        .GetAll(includeProperties: includeProps))
                        .ToList();
        }

        public async Task<PurchaseOrder> GetById(int id)
        {
            return await _unitOfWork.PurchaseOrderRepository.Get(x => x.Id == id);
        }

        public List<MostPurchasedArticlesDto> MostPurchasedArticles()
        {
            return _unitOfWork.PurchaseOrderRepository.GetMostPurchasedArticles().ToList();
        }

        public List<PurchasedArticlesByMonthDto> PurchasedArticlesByMonth()
        {
            return _unitOfWork.PurchaseOrderRepository.GetPurchasedArticlesByMonth().ToList();
        }

        public SumOfAllTimePurchasesDto SumOfAllTimePurchases()
        {
            return _unitOfWork.PurchaseOrderRepository.SumOfAllTimePurchases();
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
