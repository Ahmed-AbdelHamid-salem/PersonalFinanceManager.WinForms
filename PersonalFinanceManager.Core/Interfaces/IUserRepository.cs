using PersonalFinanceManager.Core.Models.Entities;
using System.Collections.Generic;

namespace PersonalFinanceManager.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetByID(int id);
        User GetByUsername(string username);

        IEnumerable<User> GetAll();

        int Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}