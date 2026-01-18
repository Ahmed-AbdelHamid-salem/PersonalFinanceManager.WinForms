using PersonalFinanceManager.Core.Models.Entities;
using System.Collections.Generic;

namespace PersonalFinanceManager.Core.Interfaces
{
    public interface ITransactionTypeRepository
    {
        IEnumerable<TransactionType> GetAll();
    }
}