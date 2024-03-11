using MgqsPollApp.Models.Entities;
using System.Linq.Expressions;

namespace MgqsPollApp.Repositories.Interfaces
{
    public interface IMessageRepository :IBaseRepository<Message>
    {
        Task<Message> Get(string id);
        Task<Message> Get(Expression<Func<Message, bool>> predicate);
        Task<ICollection<Message>> GetSelected(List<string> ids);
        Task<ICollection<Message>> GetSelected(Expression<Func<Message, bool>> predicate);
        Task<ICollection<Message>> GetAll();
    }
}
