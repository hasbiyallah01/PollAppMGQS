using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
<<<<<<< HEAD
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
=======
using static MgqsPollApp.Models.Entities.User;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;
>>>>>>> 1f297043479d5eaca1bad7c6736d16b2fb8c7bcf

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
<<<<<<< HEAD
                           .Include(a => a.User)
                           .Include(a => a.ChatRoom)
                           .Include(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                           .ThenInclude(a => a.PollOption)
                           .SingleOrDefaultAsync(a => a.Id == id);
=======
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .SingleOrDefaultAsync(a => a.Id == id);

>>>>>>> 1f297043479d5eaca1bad7c6736d16b2fb8c7bcf
            return poll;
        }

        public async Task<Poll> Get(Expression<Func<Poll, bool>> predicate)
        {
            var poll = await _context.Set<Poll>()
<<<<<<< HEAD
                           .Include(a => a.User)
                           .Include(a => a.ChatRoom)
                           .Include(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                           .ThenInclude(a => a.PollOption)
                           .SingleOrDefaultAsync(predicate);
                           return poll;
=======
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .SingleOrDefaultAsync(predicate);

            return poll;
>>>>>>> 1f297043479d5eaca1bad7c6736d16b2fb8c7bcf
        }

        public async Task<ICollection<Poll>> GetAll()
        {
            var polls = await _context.Set<Poll>()
<<<<<<< HEAD
                            .Include(a => a.User)
                            .Include(a => a.ChatRoom)
                            .Include(a => a.Options)
                            .ThenInclude(a => a.UserSelections)
                            .ThenInclude(a => a.PollOption)
                            .ToListAsync();
=======
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .ToListAsync();

>>>>>>> 1f297043479d5eaca1bad7c6736d16b2fb8c7bcf
            return polls;
        }

        public async Task<ICollection<Poll>> GetSelected(List<int> ids)
        {
            var polls = await _context.Set<Poll>()
<<<<<<< HEAD
                        .Include(a => a.User)
                        .Include(a => a.ChatRoom)
                        .Include(a => a.Options)
                        .ThenInclude(a => a.UserSelections)
                        .ThenInclude(a => a.PollOption)
                        .ToListAsync();
                        return polls;
=======
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .Where(a => ids.Contains(a.Id))
                .ToListAsync();

            return polls;
>>>>>>> 1f297043479d5eaca1bad7c6736d16b2fb8c7bcf
        }

        public async Task<ICollection<Poll>> GetSelected(Expression<Func<Poll, bool>> predicate)
        {
            var polls = await _context.Set<Poll>()
<<<<<<< HEAD
                        .Include(a => a.User)
                        .Include(a => a.ChatRoom)
                        .Include(a => a.Options)
                        .ThenInclude(a => a.UserSelections)
                        .ThenInclude(a => a.PollOption)
                        .Where(predicate)
                        .ToListAsync();
                        return polls;
=======
                    .Include(a => a.User)
                    .Include(a => a.Deadline)
                    .Include(a => a.ChatRoom)
                    .ThenInclude(a => a.ChatRoomUsers)
                    .Include(a => a.CreatedAt)
                .Where(predicate)
                .ToListAsync();

            return polls;
>>>>>>> 1f297043479d5eaca1bad7c6736d16b2fb8c7bcf
        }
    }
}