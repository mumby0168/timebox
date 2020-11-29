using System;
using System.Threading.Tasks;
using Timebox.Backlog.Application.Interfaces.Services;

namespace Timebox.Backlog.Infastructure.Services
{
    public class UserService : IUserService
    {
        public Task<Guid> GetAccountIdForCurrentUserAsync()
        {
            //TODO: replace this with some code from rob
            return Task.FromResult(Guid.NewGuid());
        }
    }
}