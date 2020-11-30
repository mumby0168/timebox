using System;

namespace Timebox.Shared.Kernel.Exceptions
{
    public abstract class DomainException : Exception
    {
        public abstract string ErrorCode { get; }
        
        protected DomainException() {}

        protected DomainException(string message) : base(message)
        {
            
        }
    }
}