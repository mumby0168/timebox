using System;

namespace Timebox.Account.Domain.Exceptions
{
    // TODO: Update to derive from DomainException when merged with Billy's stuff
    public class InvalidPhoneNumberException : Exception
    {
        // TODO: public override string ErrorCode => "invalid_phone_number";
        public InvalidPhoneNumberException(string phoneNumber) : base($"The phone number ({phoneNumber}) is invalid.") {} // TODO: Change message
    }
}