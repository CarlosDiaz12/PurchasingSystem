using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Articles.DTOs
{
    public class UpdateArticleDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int MeasurementUnitId { get; set; }
        public long Stock { get; set; }
    }
}
