using System;

namespace Application.PurchaseOrders.DTOs
{
    public class CreatePurchaseOrderDto
    {
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
        public int ArticleId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public int DepartmentId { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
    }
}
