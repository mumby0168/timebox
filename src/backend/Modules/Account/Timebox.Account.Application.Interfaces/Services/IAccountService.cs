using System.Threading.Tasks;
using Timebox.Account.Domain.Entities;

namespace Timebox.Account.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AccountEntity> CreateAccountAsync(string email, string mobileNumber, string password);
    }
}