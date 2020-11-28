namespace Timebox.Shared.Kernel.Dtos
{
    public class TimeboxErrorDto
    {
        public TimeboxErrorDto(string message, string code)
        {
            Message = message;
            Code = code;
        }

        public string Message { get; }
        
        public string Code { get;  }
    }
}