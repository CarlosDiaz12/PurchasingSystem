using Application.Articles.DTOs;
using Application.Articles.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Articles.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Create(CreateArticleDTO dto)
        {
            var entity = new Article
            {
                BrandId = dto.BrandId,
                MeasurementUnitId = dto.MeasurementUnitId,
                Description = dto.Description,
                Stock = dto.Stock
            };

            await _unitOfWork.ArticleRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.ArticleRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<List<Article>> GetAll()
        {
            return (await _unitOfWork.ArticleRepository
                                    .GetAll())
                                    .ToList();
        }

        public async Task<Article> GetById(int id)
        {
            return await _unitOfWork.ArticleRepository.Get(x => x.Id == id);
        }

        public async Task Update(UpdateArticleDTO dto)
        {
            var entity = new Article
            {
                Id = dto.Id,
                BrandId = dto.BrandId,
                MeasurementUnitId = dto.MeasurementUnitId,
                Description = dto.Description,
                Stock = dto.Stock
            };

            _unitOfWork.ArticleRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
