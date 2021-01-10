using System.Threading.Tasks;
using Timebox.Account.Application.DTOs;
using Timebox.Account.Application.Interfaces.Repositories;
using Timebox.Account.Application.Interfaces.Services;
using Timebox.Account.Domain.Entities;
using Timebox.Account.Domain.Exceptions;

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
                throw new InvalidEmailException(createAccountDto.Email);

            if (!_passwordService.IsStrongPassword(createAccountDto.Password))
                throw new WeakPasswordException();

            if (!_phoneService.IsValidPhoneNumber(createAccountDto.MobileNumber))
                throw new InvalidPhoneNumberException(createAccountDto.MobileNumber);

            if (await _accountRepository.DoesAccountExistAsync(createAccountDto.Email))
                throw new AccountExistsException(createAccountDto.Email);

            var accountEntity = new AccountEntity(createAccountDto.Email, createAccountDto.MobileNumber, _passwordService.HashPassword(createAccountDto.Password));
            await _accountRepository.CreateAccountAsync(accountEntity);

            return accountEntity;
        }
    }
}