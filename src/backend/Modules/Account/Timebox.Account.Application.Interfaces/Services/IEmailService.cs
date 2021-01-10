using System.Threading.Tasks;

namespace Timebox.Account.Application.Interfaces.Services
{
    public interface IEmailService
    {
        bool IsValidEmailAddress(string email);
    }
}