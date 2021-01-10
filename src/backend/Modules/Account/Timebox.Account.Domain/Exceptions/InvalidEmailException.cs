using System;

namespace Timebox.Account.Domain.Exceptions
{
    // TODO: Update to derive from DomainException when merged with Billy's stuff
    public class InvalidEmailException : Exception
    {
        // TODO: public override string ErrorCode => "invalid_email";
        public InvalidEmailException(string email) : base($"The email address ({email}) entered is invalid.") {} // TODO: Change message
    }
}