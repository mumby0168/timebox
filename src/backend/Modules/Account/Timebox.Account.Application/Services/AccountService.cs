using System.Threading.Tasks;
using Timebox.Account.Application.DTOs;
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
        
        public async Task<AccountEntity> CreateAccountAsync(CreateAccountDto createAccountDto)
        {
            if (!_emailService.IsValidEmailAddress(createAccountDto.Email))
                return null; //ToDo: Throw

            if (!_passwordService.IsStrongPassword(createAccountDto.Password))
                return null; //ToDo: Throw

            if (!_phoneService.IsValidPhoneNumber(createAccountDto.MobileNumber))
                return null; //ToDo: Throw
            
            if (await _accountRepository.DoesAccountExistAsync(createAccountDto.Email))
                return null; //ToDo: Throw

            var accountEntity = new AccountEntity(createAccountDto.Email, createAccountDto.MobileNumber, _passwordService.HashPassword(createAccountDto.Password));
            await _accountRepository.CreateAccountAsync(accountEntity);

            return accountEntity;
        }
    }
}