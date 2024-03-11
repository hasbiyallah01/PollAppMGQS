using MgqsPollApp.Models.Entities;
using System.Linq.Expressions;
using System.Net;

namespace MgqsPollApp.Repositories.Interfaces
{
    public interface IChatRoomRepository : IBaseRepository<ChatRoom>
    {
        Task<ChatRoom> Get(int id);
        Task<ChatRoom> Get(Expression<Func<ChatRoom, bool>> predicate);
        Task<ICollection<ChatRoom>> GetSelected(List<int> ids);
        Task<ICollection<ChatRoom>> GetSelected(Expression<Func<ChatRoom, bool>> predicate);
        Task<ICollection<ChatRoom>> GetAll();
    }
}
