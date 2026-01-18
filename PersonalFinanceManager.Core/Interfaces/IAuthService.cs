using PersonalFinanceManager.Core.Models.Entities;

namespace PersonalFinanceManager.Core.Interfaces
{
    public interface IAuthService
    {
        User Login(string username, string password);
        int Register(string username, string password);
    }
}