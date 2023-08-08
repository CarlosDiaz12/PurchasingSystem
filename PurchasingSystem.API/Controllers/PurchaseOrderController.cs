using Application.PurchaseOrders.DTOs;
using Application.PurchaseOrders.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PurchasingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _service;
        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _service = purchaseOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetPurchaseOrderFilterDTO filter) => Ok(await _service.GetAll(filter));

        [HttpPost]
        public async Task<IActionResult> Create(CreatePurchaseOrderDto dto)
        {
            await _service.Create(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePurchaseOrderDto dto)
        {
            await _service.Update(dto);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _service.Delete(Id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));
        [HttpGet("PurchasedArticlesByMonth")]
        public IActionResult MostPurchasedArticlesByMonths()
        {
            return Ok(_service.PurchasedArticlesByMonth());
        }

        [HttpGet("MostPurchasedArticles")]
        public IActionResult MostPurchasedArticles()
        {
            return Ok(_service.MostPurchasedArticles());
        }


        [HttpGet("SumOfAllTimePurchases")]
        public IActionResult SumOfAllTimePurchases()
        {
            return Ok(_service.SumOfAllTimePurchases());
        }

        [HttpGet("MostPurchasedBrands")]
        public IActionResult MostPurchasedBrands()
        {
            return Ok(_service.MostPurchasedBrands());
        }
    }
}
