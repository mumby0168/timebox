using System.Threading.Tasks;
using Timebox.Account.Application.Interfaces.Repositories;
using Timebox.Account.Application.Interfaces.Services;
using Timebox.Account.Domain.Entities;

namespace Timebox.Account.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordService _passwordService;
        private readonly IEmailService _emailService;
        private readonly IPhoneService _phoneService;

        public AccountService(IAccountRepository accountRepository, IPasswordService passwordService, IEmailService emailService, IPhoneService phoneService)
        {
            _accountRepository = accountRepository;
            _passwordService = passwordService;
            _emailService = emailService;
            _phoneService = phoneService;
        }
        
        public async Task<AccountEntity> CreateAccountAsync(string email, string mobileNumber, string password)
        {
            if (!_emailService.IsValidEmailAddress(email))
                return null; //ToDo: Throw

            if (!_passwordService.IsStrongPassword(password))
                return null; //ToDo: Throw

            if (!_phoneService.IsValidPhoneNumber(mobileNumber))
                return null; //ToDo: Throw
            
            if (await _accountRepository.DoesAccountExistAsync(email))
                return null; //ToDo: Throw

            var accountEntity = new AccountEntity(email, mobileNumber, _passwordService.HashPassword(password));
            await _accountRepository.CreateAccountAsync(accountEntity);

            return accountEntity;
        }
    }
}