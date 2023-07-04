using Application.Common.Interfaces;
using Application.MeasurementUnits.DTOs;
using Domain.Entities;

namespace Application.MeasurementUnits.Interface
{
    public interface IMeasurementUnitService: IService<MeasurementUnit, CreateMeasurementUnitDTO, UpdateMeasurementUnitDTO>
    {
    }
}
