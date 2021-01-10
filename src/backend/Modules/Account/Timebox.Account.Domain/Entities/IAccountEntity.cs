using System;
using Timebox.Shared;

namespace Timebox.Account.Domain.Entities
{
    public interface IAccountEntity : IEntityBase
    {
        Guid Id { get; }
        string Email { get; }
        string MobileNumber { get; }
        string HashedPassword { get; }
    }
}