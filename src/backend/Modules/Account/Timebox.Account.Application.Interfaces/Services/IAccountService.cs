using System.Threading.Tasks;
using Timebox.Account.Application.DTOs;
using Timebox.Account.Domain.Entities;

namespace Timebox.Account.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AccountEntity> CreateAccountAsync(CreateAccountDto createAccountDto);
    }
}