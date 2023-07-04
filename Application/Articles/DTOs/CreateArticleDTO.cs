using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Articles.DTOs
{
    public class CreateArticleDTO
    {
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int MeasurementUnitId { get; set; }
        public long Stock { get; set; }
    }
}
