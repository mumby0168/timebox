using System.Threading.Tasks;

namespace Timebox.Account.Application.Interfaces.Services
{
    public interface IPhoneService
    {
        bool IsValidPhoneNumber(string mobileNumber);
    }
}