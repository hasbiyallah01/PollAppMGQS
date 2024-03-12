using MgqsPollApp.Models.Entities;
using System.Linq.Expressions;

namespace MgqsPollApp.Repositories.Interfaces
{
    public interface IPollRepository : IBaseRepository<Poll>
    {
        Task<Poll> Get(int id);
        Task<Poll> Get(Expression<Func<Poll, bool>> predicate);
        Task<ICollection<Poll>> GetSelected(List<int> ids);
        Task<ICollection<Poll>> GetSelected(Expression<Func<Poll, bool>> predicate);
        Task<ICollection<Poll>> GetAll();
    }
}
