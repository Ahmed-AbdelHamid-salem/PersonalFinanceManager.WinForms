using PersonalFinanceManager.Core.Models.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinanceManager.Core.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get(DateTime? from = null, DateTime? to = null, int? categoryId = null);
    }
}