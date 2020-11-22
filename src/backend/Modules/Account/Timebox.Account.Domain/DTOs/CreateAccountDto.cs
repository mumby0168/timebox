using System.Text.Json.Serialization;

namespace Timebox.Account.Application.DTOs
{
    public class CreateAccountDto
    {
        public string Email { get; }
        public string MobileNumber { get; }
        public string Password { get; }

        [JsonConstructor]
        public CreateAccountDto(string email, string mobileNumber, string password)
        {
            Email = email;
            MobileNumber = mobileNumber;
            Password = password;
        }
    }
}