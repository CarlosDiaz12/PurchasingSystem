using Application.Common.Interfaces;
using Application.External.DTOs;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public async Task<ActionResult<CreateAccountingEntryResultDTO>> CreateAccountingEntry(CreateAccountingEntryDTO dto)
        {
            var result = await _externalServices.CreateAccountingEntry(dto);
            return Ok(result);
        }
    }
}
