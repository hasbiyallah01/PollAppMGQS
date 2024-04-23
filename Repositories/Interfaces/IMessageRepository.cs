using MgqsPollApp.Models.Entities;
using System.Linq.Expressions;

namespace MgqsPollApp.Repositories.Interfaces
{
    public interface IMessageRepository :IBaseRepository<Message>
    {
        Task CreateAsync(Message message);
        Task<Message> Get(int id);
        Task<Message> Get(Expression<Func<Message, bool>> predicate);
        Task<ICollection<Message>> GetSelected(List<int> ids);
        Task<ICollection<Message>> GetSelected(Expression<Func<Message, bool>> predicate);
        Task<ICollection<Message>> GetAll();
    }
}

