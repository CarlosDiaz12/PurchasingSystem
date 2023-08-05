using System;
using System.Collections.Generic;
using System.Text;

namespace Application.External.DTOs
{
    public class CreateAccountingEntryExternalDTO
    {
        public string Descripcion { get; set; }
        public int Auxiliar { get; set; }
        public int CuentaDB { get; set; }
        public int CuentaCR { get; set; }
        public decimal Monto { get; set; }
    }
}
