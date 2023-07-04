using Application.Departments.DTOs;
using Application.Departments.Interface;
using Application.Repositories;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Departments.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Create(CreateDepartmentDTO dto)
        {
            var entity = new Department
            {
                Name = dto.Name,
            };

            await _unitOfWork.DepartmentRepository.Insert(entity);
            await _unitOfWork.Commit();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.DepartmentRepository.Delete(id);
            await _unitOfWork.Commit();
        }

        public async Task<List<Department>> GetAll()
        {
            return (await _unitOfWork.DepartmentRepository
                                    .GetAll())
                                    .ToList();
        }

        public async Task<Department> GetById(int id)
        {
            return await _unitOfWork.DepartmentRepository.Get(x => x.Id == id);
        }

        public async Task Update(UpdateDepartmentDTO dto)
        {
            var entity = new Department
            {
                Id = dto.Id,
                Name = dto.Description,
            };

            _unitOfWork.DepartmentRepository.Update(entity);
            await _unitOfWork.Commit();
        }
    }
}
