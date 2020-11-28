using System.Threading.Tasks;
using Timebox.Backlog.Application.Dtos;

namespace Timebox.Backlog.Application.Services
{
    public interface IBacklogService
    {
        Task CreateAsync(CreateBacklogDto backlogDto);
    }
}