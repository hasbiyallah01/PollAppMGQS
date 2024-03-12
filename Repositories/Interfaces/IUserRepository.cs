using MgqsPollApp.Models.Entities;
using System.Linq.Expressions;
using System.Net;

namespace MgqsPollApp.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Get(int id);
        Task<User> Get(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetSelected(List<int> ids);
        Task<ICollection<User>> GetSelected(Expression<Func<User, bool>> predicate);
        Task<ICollection<User>> GetAll();
    }
}
