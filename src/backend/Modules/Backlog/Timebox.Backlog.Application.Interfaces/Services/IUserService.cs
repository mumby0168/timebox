using System;
using System.Threading.Tasks;

namespace Timebox.Backlog.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Guid> GetAccountIdForCurrentUserAsync();
    }
}