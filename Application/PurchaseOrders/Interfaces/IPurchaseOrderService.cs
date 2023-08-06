using Application.Common.Interfaces;
using Application.PurchaseOrders.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.Interfaces
{
    public interface IPurchaseOrderService: IService<PurchaseOrder, CreatePurchaseOrderDto, UpdatePurchaseOrderDto>
    {
        List<PurchasedArticlesByMonthDto> PurchasedArticlesByMonth();
        List<MostPurchasedArticlesDto> MostPurchasedArticles();
        SumOfAllTimePurchasesDto SumOfAllTimePurchases();
    }
}
