using System;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Timebox.Account.Application.Interfaces.Repositories;
using Timebox.Account.Domain.Entities;
using Timebox.Account.Infrastructure.Documents;

namespace Timebox.Account.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoRepository<AccountDocument, Guid> _accountRepository;

        public AccountRepository(IMongoRepository<AccountDocument, Guid> accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        public async Task CreateAccountAsync(IAccountEntity accountEntity)
        {
            if (accountEntity == null)
                return;
            
            await _accountRepository.AddAsync(new AccountDocument(accountEntity));
        }

        public async Task<IAccountEntity> GetAccountAsync(Guid accountId)
        {
            return (await _accountRepository.GetAsync(accountId))?.AsEntity();
        }

        public async Task<IAccountEntity> GetAccountAsync(string email)
        {
            if (email == null)
                return null;
            
            return (await _accountRepository.GetAsync(ad => ad.Email == email))?.AsEntity();
        }

        public async Task<bool> DoesAccountExistAsync(Guid accountId)
        {
            return await _accountRepository.ExistsAsync(ad => ad.Id == accountId);
        }

        public async Task<bool> DoesAccountExistAsync(string email)
        {
            return await _accountRepository.ExistsAsync(ad => ad.Email == email);
        }

        public async Task UpdateAccountAsync(IAccountEntity updatedAccountEntity)
        {
            if (updatedAccountEntity == null)
                return;
            
            var updatedAccountDocument = await _accountRepository.GetAsync(updatedAccountEntity.Id);

            if (updatedAccountDocument == null)
                return;
                
            updatedAccountDocument.Email = updatedAccountEntity.Email;
            updatedAccountDocument.MobileNumber = updatedAccountEntity.MobileNumber;
            updatedAccountDocument.HashedPassword = updatedAccountEntity.HashedPassword;
            
            await _accountRepository.UpdateAsync(updatedAccountDocument);
        }
    }
}