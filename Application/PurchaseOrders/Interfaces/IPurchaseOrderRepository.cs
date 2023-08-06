using Application.PurchaseOrders.DTOs;
using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.Interfaces
{
    public interface IPurchaseOrderRepository: IBaseRepository<PurchaseOrder>
    {
        IEnumerable<PurchasedArticlesByMonthDto> GetPurchasedArticlesByMonth();
        IEnumerable<MostPurchasedArticlesDto> GetMostPurchasedArticles();
        SumOfAllTimePurchasesDto SumOfAllTimePurchases();
    }
}
