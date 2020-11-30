using System.Threading.Tasks;
using Timebox.Backlog.Domain.Entities;

namespace Timebox.Backlog.Application.Interfaces.Repositories
{
    public interface IBacklogRepository
    {
        Task CreateAsync(IBacklogEntity backlog);
    }
}