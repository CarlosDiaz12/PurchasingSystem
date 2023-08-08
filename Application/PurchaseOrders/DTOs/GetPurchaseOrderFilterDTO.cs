using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.DTOs
{
    public class GetPurchaseOrderFilterDTO
    {
        public int? ArticleId { get; set; }
        public int? SupplierId { get; set; }
        public int? DepartmentId { get; set; }
    }
}
