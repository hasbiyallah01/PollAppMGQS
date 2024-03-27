using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using static MgqsPollApp.Models.Entities.User;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

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
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .SingleOrDefaultAsync(a => a.Id == id);

            return poll;
        }

        public async Task<Poll> Get(Expression<Func<Poll, bool>> predicate)
        {
            var poll = await _context.Set<Poll>()
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .SingleOrDefaultAsync(predicate);

            return poll;
        }

        public async Task<ICollection<Poll>> GetAll()
        {
            var polls = await _context.Set<Poll>()
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .ToListAsync();

            return polls;
        }

        public async Task<ICollection<Poll>> GetSelected(List<int> ids)
        {
            var polls = await _context.Set<Poll>()
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();

            return polls;
        }

        public async Task<ICollection<Poll>> GetSelected(Expression<Func<Poll, bool>> predicate)
        {
            var polls = await _context.Set<Poll>()
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .Where(predicate)
                .ToListAsync();

            return polls;
        }
    }
}