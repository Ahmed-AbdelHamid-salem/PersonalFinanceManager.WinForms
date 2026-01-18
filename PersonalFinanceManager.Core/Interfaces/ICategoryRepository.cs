using PersonalFinanceManager.Core.Models.Entities;
using System.Collections.Generic;

namespace PersonalFinanceManager.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetByID(int id);
        IEnumerable<Category> Get(int? transactionTypeId = null, bool? isActive = null);

        int Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
