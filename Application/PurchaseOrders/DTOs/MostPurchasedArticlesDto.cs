﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.DTOs
{
    public class MostPurchasedArticlesDto
    {
        public string ArticleName { get; set; }
        public decimal Total { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}
