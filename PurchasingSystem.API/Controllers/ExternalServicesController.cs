using Application.Common.Interfaces;
using Application.External.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PurchasingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalServicesController : ControllerBase
    {
        private readonly IExternalServices _externalServices;
        public ExternalServicesController(IExternalServices externalServices)
        {
            _externalServices = externalServices;
        }

        [HttpPost("CreateAccountingEntry")]
        public async Task<ActionResult<CreateAccountingEntryResultDTO>> CreateAccountingEntry(CreateAccountingEntryDTO dto)
        {
            var result = await _externalServices.CreateAccountingEntry(dto);
            return Ok(result);
        }

        [HttpGet("GetAccountingEntries")]
        public async Task<ActionResult<GetAccountingEntriesDTO>> GetAccountingEntries()
        {
            return Ok(await _externalServices.GetAccountingEntries());
        }
    }
}
