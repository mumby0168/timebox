using System;
using System.Threading.Tasks;
using Timebox.Account.Domain.Entities;
using Timebox.Shared;

namespace Timebox.Account.Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccountAsync(IAccountEntity accountEntity);
        Task<IAccountEntity> GetAccountAsync(Guid accountId);
        Task<IAccountEntity> GetAccountAsync(string email);
        Task<bool> DoesAccountExistAsync(Guid accountId);
        Task<bool> DoesAccountExistAsync(string email);
        Task UpdateAccountAsync(IAccountEntity updatedAccountEntity);
    }
}