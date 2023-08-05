using Application.External.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IExternalServices
    {
        Task<CreateAccountingEntryResultDTO> CreateAccountingEntry(CreateAccountingEntryDTO dto);
    }
}
