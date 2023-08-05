using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class PurchaseOrder: BaseEntity
    {
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int Quantity { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
    }
}
