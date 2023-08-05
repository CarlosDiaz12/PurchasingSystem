using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.External.DTOs
{
    public class CreateAccountingEntryDTO
    {
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
