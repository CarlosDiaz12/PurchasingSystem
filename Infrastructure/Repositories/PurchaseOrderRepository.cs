using Application.PurchaseOrders.DTOs;
using Application.PurchaseOrders.Interfaces;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {

        public PurchaseOrderRepository(AppDbContext appDbContext): base(appDbContext)
        {

        }

        public IEnumerable<MostPurchasedArticlesDto> GetMostPurchasedArticles()
        {
            return _dbSet
            .Include(x => x.Article)
            .GroupBy(x => x.Article.Description)
            .Select(x => new MostPurchasedArticlesDto
            {
                ArticleName = x.Key,
                TotalQuantity = x.Sum(x => x.Quantity),
                Total = x.Sum(x => x.Total)
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(5);
        }

        public IEnumerable<PurchasedArticlesByMonthDto> GetPurchasedArticlesByMonth()
        {

            var data =  _dbSet
                          .Include(x => x.Article)
                         .Select(x => new { x.Article.Description, x.Date.Month, x.Quantity, x.Total })
                         .GroupBy(x => new { x.Month })
                        .Select(x => new PurchasedArticlesByMonthDto
                        {
                            Total = x.Sum(x => x.Total),
                            Month = Enum.GetName<Months>(Enum.Parse<Months>(x.Key.Month.ToString())),
                            Articles = x.GroupBy(x => new { x.Description }).Select(x => new ArticleDto { Name = x.Key.Description, Quantity = x.Sum(x => x.Quantity)}).ToList()
                        });
            return data;
        }

        public SumOfAllTimePurchasesDto SumOfAllTimePurchases()
        {
            var data =  _dbSet
                    .GroupBy(x => x.ArticleId)
                     .Select(x => new
                     {

                         TotalQuantity = x.Sum(x => x.Quantity),
                         Total = x.Sum(x => x.Total)
                     });
            return new SumOfAllTimePurchasesDto
            {
                Total = data.Sum(x => x.Total),
                TotalQuantity = data.Sum(x => x.TotalQuantity)
            };
        }
    }
}
