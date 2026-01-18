using PersonalFinanceManager.Core.Models.Entities;
using System.Collections.Generic;

namespace PersonalFinanceManager.Core.Interfaces
{
    public interface ICategoryService
    {
        Category GetById(int id);
        IEnumerable<Category> GetCategories(int? transactionTypeId = null, bool? isActive = null);

        int Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}