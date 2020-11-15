using System;
using Convey.Types;
using Timebox.Account.Domain.Entities;

namespace Timebox.Account.Infrastructure.Documents
{
    public class AccountDocument : IIdentifiable<Guid>
    {
        public AccountDocument()
        {
            
        }
        
        public AccountDocument(IAccountEntity accountEntity)
        {
            Id = accountEntity.Id;
            Email = accountEntity.Email;
            MobileNumber = accountEntity.MobileNumber;
            HashedPassword = accountEntity.HashedPassword;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string HashedPassword { get; set; }

        public IAccountEntity AsEntity()
        {
            return new AccountEntity(Id, Email, MobileNumber, HashedPassword);
        }
    }
}