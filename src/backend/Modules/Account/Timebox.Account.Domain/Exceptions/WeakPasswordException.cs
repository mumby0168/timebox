using System;

namespace Timebox.Account.Domain.Exceptions
{
    // TODO: Update to derive from DomainException when merged with Billy's stuff
    public class WeakPasswordException : Exception
    {
        // TODO: public override string ErrorCode => "weak_password";
        public WeakPasswordException() : base("The password must be at least 8 characters and contain one number, one special character (_!@#$&*) and at lease one upper case character.") {} // TODO: Change message
    }
}