using MgqsPollApp.Models.Entities;
using System.Linq.Expressions;
using System.Net;

namespace MgqsPollApp.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Get(string id);
        Task<User> Get(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetSelected(List<string> ids);
        Task<ICollection<User>> GetSelected(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetAll();
    }
}
