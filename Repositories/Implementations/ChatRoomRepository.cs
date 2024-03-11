using MgqsPollApp.Context;
using MgqsPollApp.Models.Entities;
using MgqsPollApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;

namespace MgqsPollApp.Repositories.Implementations
{
    public class ChatRoomRepository : BaseRepository<ChatRoom>, IChatRoomRepository
    {
        public ChatRoomRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ChatRoom> Get(int id)
        {
            var chatRoom = await _context.Set<ChatRoom>()
                           .Include(a => a.Messages)
                           .Include(a => a.ChatRoomUsers)
                           .ThenInclude(a => a.User)
                           .SingleOrDefaultAsync(a => a.Id == id);
                           return chatRoom;
        }

        public async Task<ChatRoom> Get(Expression<Func<ChatRoom, bool>> predicate)
        {
            var chatRoom = await _context.Set<ChatRoom>()
                           .Include(a => a.Messages)
                           .Include(a => a.ChatRoomUsers)
                           .ThenInclude(a => a.User)
                           .SingleOrDefaultAsync(predicate);
                           return chatRoom;
        }

        public async Task<ICollection<ChatRoom>> GetAll()
        {
            var chatRooms = await _context.Set<ChatRoom>()
                            .Include(a => a.Messages)
                            .Include(a => a.ChatRoomUsers)
                            .ThenInclude(a => a.User)
                            .ToListAsync();
                            return chatRooms;
        }

        public async Task<ICollection<ChatRoom>> GetSelected(List<int> ids)
        {
            var chatRooms = await _context.Set<ChatRoom>()
                            .Include(a => a.Messages)
                            .Include(a => a.ChatRoomUsers)
                            .ThenInclude(a => a.User)
                            .Where(a => ids.Contains(a.Id)).ToListAsync();
                            return chatRooms;
        }

        public async Task<ICollection<ChatRoom>> GetSelected(Expression<Func<ChatRoom, bool>> predicate)
        {
            var chatRooms = await _context.Set<ChatRoom>()
                            .Include(a => a.Messages)
                            .Include(a => a.ChatRoomUsers)
                            .ThenInclude(a => a.User)
                            .Where(predicate).ToListAsync();
                            return chatRooms;
        }
    }
}
