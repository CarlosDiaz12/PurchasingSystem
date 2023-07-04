using Application.Common.Interfaces;
using Application.Departments.DTOs;
using Domain.Entities;

namespace Application.Departments.Interface
{
    public interface IDepartmentService: IService<Department, CreateDepartmentDTO, UpdateDepartmentDTO>
    {
    }
}
