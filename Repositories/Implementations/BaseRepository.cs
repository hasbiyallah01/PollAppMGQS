using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace MgqsPollApp.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected ApplicationContext _context;
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>()
                .AddAsync(entity);
            return entity;
        }

        public async Task<int> Save()
        {
            return await _context
                .SaveChangesAsync();
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
    }
}
