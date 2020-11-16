using System.Threading.Tasks;

namespace Timebox.Account.Application.Interfaces.Services
{
    public interface IPasswordService
    {
        bool IsStrongPassword(string password);
        string HashPassword(string password);
    }
}