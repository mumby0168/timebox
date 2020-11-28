using System;
using System.Threading.Tasks;
using Timebox.Backlog.Application.Interfaces.Services;

namespace Timebox.Backlog.Infastructure.Services
{
    public class UserService : IUserService
    {
        public Task<Guid> GetAccountIdForCurrentUserAsync()
        {
            throw new NotImplementedException();
        }
    }
}