namespace Timebox.Account.Application.DTOs
{
    public class CreateAccountDTO
    {
        public string Email { get; }
        public string MobileNumber { get; }
        public string Password { get; }

        public CreateAccountDTO(string email, string mobileNumber, string password)
        {
            Email = email;
            MobileNumber = mobileNumber;
            Password = password;
        }
    }
}