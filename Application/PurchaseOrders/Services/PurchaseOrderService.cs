using Application.Common.Exceptions;
using Application.PurchaseOrders.DTOs;
using Application.PurchaseOrders.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Util;

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

        private async Task<string> CreateOrderSequence()
        {
            var orderCount = (await _unitOfWork.PurchaseOrderRepository.GetAll()).ToList().Count;
            string newSequence = orderCount.ToString();
            return newSequence.PadLeft(5, '0');
        }

        public async Task Create(CreatePurchaseOrderDto dto)
        {
            var entity = new PurchaseOrder
            {
                Date = dto.Date,
                ArticleId = dto.ArticleId,
                SupplierId = dto.SupplierId,
                Quantity = dto.Quantity,
                DepartmentId = dto.DepartmentId,
                UnitCost = dto.UnitCost,
                Total = dto.Total
            };

            entity.OrderNumber = await CreateOrderSequence();

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

        public async Task<List<PurchaseOrder>> GetAll(GetPurchaseOrderFilterDTO dto)
        {
            string includeProps = $"{nameof(PurchaseOrder.Article)}," +
                                 $"{nameof(PurchaseOrder.Department)}," +
                                 $"{nameof(PurchaseOrder.Supplier)}";

            var filter = PredicateBuilder.True<PurchaseOrder>();

            if(dto.SupplierId.HasValue)
                filter = filter.And(x => x.SupplierId == dto.SupplierId.Value);


            if (dto.DepartmentId.HasValue)
                filter = filter.And(x => x.DepartmentId == dto.DepartmentId.Value);


            if (dto.ArticleId.HasValue)
                filter = filter.And(x => x.ArticleId == dto.ArticleId.Value);



            return (await _unitOfWork.PurchaseOrderRepository
                        .GetAll(filter,includeProperties: includeProps))
                        .ToList();
        }
    }
}
