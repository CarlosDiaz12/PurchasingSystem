using Domain.Common;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Supplier: BaseEntity
    {
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public IdentificationType IdentificationType { get; set; }
    }
}
