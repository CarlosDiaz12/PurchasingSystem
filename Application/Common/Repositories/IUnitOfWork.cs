using System;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        Task Commit();
    }
}
