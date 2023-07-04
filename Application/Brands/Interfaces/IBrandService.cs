using Application.Brands.DTOs;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Brands.Interfaces
{
    public interface IBrandService: IService<Brand, CreateBrandDTO, UpdateBrandDTO>
    {
    }
}
