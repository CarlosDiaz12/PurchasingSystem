using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.DTOs
{
    public class PurchasedArticlesByMonthDto
    {
        public string Month { get; set; }
        public decimal Total { get; set; }
        public List<ArticleDto> Articles { get; set; }
    }

    public class ArticleDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
