using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MgqsPollApp.Repositories.Implementations
{
    public class MessageRepository: BaseRepository<Message>, IMessageRepository
    {
        public MessageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Message> Get(int id)
        {
            var message = await _context.Set<Message>()
                           .Include(a => a.ChatRoom)
                           .Include(a => a.User)
                           .ThenInclude(a => a.Polls)
                           .ThenInclude(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                           .SingleOrDefaultAsync(a => a.Id == id);
                            return message;
        }

        public async Task<Message> Get(Expression<Func<Message, bool>> predicate)
        {
            var message = await _context.Set<Message>()
                           .Include(a => a.ChatRoom)
                           .Include(a => a.User)
                           .ThenInclude(a => a.Polls)
                           .ThenInclude(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                           .SingleOrDefaultAsync(predicate);
                            return message;
        }

        public async Task<ICollection<Message>> GetAll()
        {
            var chatRooms = await _context.Set<Message>()
                            .Include(a => a.ChatRoom)
                           .Include(a => a.User)
                           .ThenInclude(a => a.Polls)
                           .ThenInclude(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                            .ToListAsync();
                            return chatRooms;
        }

        public async Task<ICollection<Message>> GetSelected(List<int> ids)
        {
            var chatRooms = await _context.Set<Message>()
                            .Include(a => a.ChatRoom)
                           .Include(a => a.User)
                           .ThenInclude(a => a.Polls)
                           .ThenInclude(a => a.Options)
                           .ThenInclude(a => a.UserSelections)
                            .Where(a => ids.Contains(a.Id)).ToListAsync();
            return chatRooms;
        }

        public async Task<ICollection<Message>> GetSelected(Expression<Func<Message, bool>> predicate)
        {
            var chatRooms = await _context.Set<Message>()
                            .Include(a => a.ChatRoom)
                            .Include(a => a.User)
                            .ThenInclude(a => a.Polls)
                            .ThenInclude(a => a.Options)
                            .ThenInclude(a => a.UserSelections)
                            .Where(predicate).ToListAsync();
            return chatRooms;
        }
    }
}
