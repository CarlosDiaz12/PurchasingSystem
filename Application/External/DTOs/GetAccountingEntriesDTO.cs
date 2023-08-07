using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.External.DTOs
{
    public class GetAccountingEntriesDTO
    {
        public List<AccountingEntryDTO> AsientoContable { get; set; }

    }

    public class AccountingEntryDTO
    {
        public int Auxiliar { get; set; }
        public int CuentaContable { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public string TipoMovimiento { get; set; }
    }
}
