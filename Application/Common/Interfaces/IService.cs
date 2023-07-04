using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IService<TEntity,TCreate, TUpdate> where TCreate : class where TUpdate : class where TEntity : BaseEntity
    {
        Task Create(TCreate dto);
        Task Update(TUpdate dto);   
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Delete(int id);
    }
}
