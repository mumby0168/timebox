using System;

namespace Timebox.Account.Domain.Exceptions
{
    // TODO: Update to derive from DomainException when merged with Billy's stuff
    public class AccountExistsException : Exception
    {
        // TODO: public override string ErrorCode => "invalid_email";
        public AccountExistsException(string email) : base($"An account with the email address ({email}) already exists.") { } // TODO: Change message
    }
}