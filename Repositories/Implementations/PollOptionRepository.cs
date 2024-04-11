using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MgqsPollApp.Repositories.Implementations
{
    public class PollOptionRepository : BaseRepository<PollOption>, IPollOptionRepository
    {
        public PollOptionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<PollOption> Get(int id)
        {
            var pollOption = await _context.Set<PollOption>()
                           .Include(a => a.UserSelections)
                           .ThenInclude(a => a.User)
                           .ThenInclude(a => a.Messages)
                           .ThenInclude(a => a.ChatRoom)
                           .ThenInclude(a => a.ChatRoomUsers)
                           .SingleOrDefaultAsync(a => a.Id == id);
            return pollOption;
        }

        public async Task<PollOption> Get(Expression<Func<PollOption, bool>> predicate)
        {
            var pollOption = await _context.Set<PollOption>()
                           .Include(a => a.UserSelections)
                           .ThenInclude(a => a.User)
                           .ThenInclude(a => a.Messages)
                           .ThenInclude(a => a.ChatRoom)
                           .ThenInclude(a => a.ChatRoomUsers)
                           .SingleOrDefaultAsync(predicate);
                            return pollOption;
        }

        public async Task<ICollection<PollOption>> GetAll()
        {
            var pollOptions = await _context.Set<PollOption>()
                            .Include(a => a.UserSelections)
                            .ThenInclude(a => a.User)
                            .ThenInclude(a => a.Messages)
                            .ThenInclude(a => a.ChatRoom)
                            .ThenInclude(a => a.ChatRoomUsers)
                            .ToListAsync();
                            return pollOptions;
        }

        public async Task<ICollection<PollOption>> GetSelected(List<int> ids)
        {
            var pollOptions = await _context.Set<PollOption>()
                            .Include(a => a.UserSelections)
                            .ThenInclude(a => a.User)
                            .ThenInclude(a => a.Messages)
                            .ThenInclude(a => a.ChatRoom)
                            .ThenInclude(a => a.ChatRoomUsers)
                            .Where(a => ids.Contains(a.Id)).ToListAsync();
                            return pollOptions;
        }

        public async Task<ICollection<PollOption>> GetSelected(Expression<Func<PollOption, bool>> predicate)
        {
            var pollOptions = await _context.Set<PollOption>()
                            .Include(a => a.UserSelections)
                            .ThenInclude(a => a.User)
                            .ThenInclude(a => a.Messages)
                            .ThenInclude(a => a.ChatRoom)
                            .ThenInclude(a => a.ChatRoomUsers)
                            .Where(predicate).ToListAsync();
            return pollOptions;
        }
    }
}
