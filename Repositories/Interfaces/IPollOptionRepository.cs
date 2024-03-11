using MgqsPollApp.Models.Entities;
using System.Linq.Expressions;

namespace MgqsPollApp.Repositories.Interfaces
{
    public interface IPollOptionRepository :IBaseRepository<PollOption>
    {
        Task<PollOption> Get(string id);
        Task<PollOption> Get(Expression<Func<PollOption, bool>> predicate);
        Task<ICollection<PollOption>> GetSelected(List<string> ids);
        Task<ICollection<PollOption>> GetSelected(Expression<Func<PollOption, bool>> predicate);
        Task<ICollection<PollOption>> GetAll();
    }
}
