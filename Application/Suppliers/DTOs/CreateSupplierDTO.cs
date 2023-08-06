using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Suppliers.DTOs
{
    public class CreateSupplierDTO
    {
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public IdentificationType IdentificationType { get; set; }
    }
}
