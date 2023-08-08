using Application.Articles.DTOs;
using Application.Articles.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PurchasingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _service;
        private readonly AppDbContext _dbContext;
        public ArticleController(IArticleService service, AppDbContext Context)
        {
            _service = service;
            _dbContext = Context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleDTO dto)
        {
            await _service.Create(dto);
            return Ok();
        }

        [HttpGet("getTotalArticles")]
        public async Task<IActionResult> getCountArticles()
        {
            var result =  await _dbContext.Articles.CountAsync();
            return Ok(result);  
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateArticleDTO dto)
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
    }
}
