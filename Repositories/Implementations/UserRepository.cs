using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace MgqsPollApp.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> Get(int id)
        {
            var user = await _context.Set<User>()
                           .Include(a => a.Messages)
                           .Include(a => a.ChatRoomUsers)
                           .ThenInclude(a => a.User)
                           .SingleOrDefaultAsync(a => a.Id == id);
                           return user;
        }

        public async Task<User> Get(Expression<Func<User, bool>> predicate)
        {
            var user = await _context.Set<User>()
                           .Include(a => a.Messages)
                           .Include(a => a.ChatRoomUsers)
                           .ThenInclude(a => a.User)
                           .SingleOrDefaultAsync(predicate);
                           return user;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var user = await _context.Set<User>()
                            .Include(a => a.Messages)
                            .Include(a => a.ChatRoomUsers)
                            .ThenInclude(a => a.User)
                            .ToListAsync();
                            return user;
        }

        public async Task<ICollection<User>> GetSelected(List<int> ids)
        {
            var user = await _context.Set<User>()
                            .Include(a => a.Messages)
                            .Include(a => a.ChatRoomUsers)
                            .ThenInclude(a => a.User)
                            .Where(a => ids.Contains(a.Id)).ToListAsync();
                            return user;
        }

        public async Task<ICollection<User>> GetSelected(Expression<Func<User, bool>> predicate)
        {
            var user = await _context.Set<User>()
                            .Include(a => a.Messages)
                            .Include(a => a.ChatRoomUsers)
                            .ThenInclude(a => a.User)
                            .Where(predicate).ToListAsync();
                            return user;
        }
    }
}
