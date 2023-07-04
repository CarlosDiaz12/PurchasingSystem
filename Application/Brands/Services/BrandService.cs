using Application.Brands.DTOs;
using Application.Brands.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Brands.Services
{
    public class BrandService: IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Create(CreateBrandDTO dto)
        {
            var entity = new Brand
            {
                Description = dto.Description,
            };

            await _unitOfWork.BrandRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.BrandRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<List<Brand>> GetAll()
        {
            return (await _unitOfWork.BrandRepository
                                    .GetAll())
                                    .ToList();
        }

        public async Task<Brand> GetById(int id)
        {
            return await _unitOfWork.BrandRepository.Get(x => x.Id == id);
        }

        public async Task Update(UpdateBrandDTO dto)
        {
            var entity = new Brand
            {
                Id = dto.Id,
                Description = dto.Description,
            };

            _unitOfWork.BrandRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
