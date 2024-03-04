using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;

namespace MgqsPollApp.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
