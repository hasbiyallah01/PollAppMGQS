using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MgqsPollApp.Repositories.Implementations
{
    public class PollRepository : BaseRepository<Poll>, IPollRepository
    {
        public PollRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Poll> Get(int id)
        {
            var poll = await _context.Set<Poll>()
                           .Include(a => a.User)
                           .Include(a => a.ChatRoom)
                           .Include(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                           .ThenInclude(a => a.PollOption)
                           .SingleOrDefaultAsync(a => a.Id == id);
            return poll;
        }

        public async Task<Poll> Get(Expression<Func<Poll, bool>> predicate)
        {
            var poll = await _context.Set<Poll>()
                           .Include(a => a.User)
                           .Include(a => a.ChatRoom)
                           .Include(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                           .ThenInclude(a => a.PollOption)
                           .SingleOrDefaultAsync(predicate);
                           return poll;
        }

        public async Task<ICollection<Poll>> GetAll()
        {
            var polls = await _context.Set<Poll>()
                            .Include(a => a.User)
                            .Include(a => a.ChatRoom)
                            .Include(a => a.Options)
                            .ThenInclude(a => a.UserSelections)
                            .ThenInclude(a => a.PollOption)
                            .ToListAsync();
            return polls;
        }

        public async Task<ICollection<Poll>> GetSelected(List<int> ids)
        {
            var polls = await _context.Set<Poll>()
                        .Include(a => a.User)
                        .Include(a => a.ChatRoom)
                        .Include(a => a.Options)
                        .ThenInclude(a => a.UserSelections)
                        .ThenInclude(a => a.PollOption)
                        .ToListAsync();

            return polls;
        }

        public async Task<ICollection<Poll>> GetSelected(Expression<Func<Poll, bool>> predicate)
        {
            var polls = await _context.Set<Poll>()
                        .Include(a => a.User)
                        .Include(a => a.ChatRoom)
                        .Include(a => a.Options)
                        .ThenInclude(a => a.UserSelections)
                        .ThenInclude(a => a.PollOption)
                        .Where(predicate)
                        .ToListAsync();
            return polls;
        }
    }
}