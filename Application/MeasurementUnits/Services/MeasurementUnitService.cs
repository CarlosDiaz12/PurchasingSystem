using Application.MeasurementUnits.DTOs;
using Application.MeasurementUnits.Interface;
using Application.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.MeasurementUnits.Services
{
    public class MeasurementUnitService: IMeasurementUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeasurementUnitService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Create(CreateMeasurementUnitDTO dto)
        {
            var entity = new MeasurementUnit
            {
                Description = dto.Description,
            };

            await _unitOfWork.MeasurementUnitRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.MeasurementUnitRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<List<MeasurementUnit>> GetAll()
        {
            return (await _unitOfWork.MeasurementUnitRepository
                                    .GetAll())
                                    .ToList();
        }

        public async Task<MeasurementUnit> GetById(int id)
        {
            return await _unitOfWork.MeasurementUnitRepository.Get(x => x.Id == id);
        }

        public async Task Update(UpdateMeasurementUnitDTO dto)
        {
            var entity = new MeasurementUnit
            {
                Id = dto.Id,
                Description = dto.Description,
            };

            _unitOfWork.MeasurementUnitRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
