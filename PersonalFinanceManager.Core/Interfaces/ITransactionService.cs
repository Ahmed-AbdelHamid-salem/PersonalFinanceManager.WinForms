using PersonalFinanceManager.Core.Models.Entities;
using System;
using System.Collections.Generic;

namespace PersonalFinanceManager.Core.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactions(DateTime? from = null, 
                                                 DateTime? to = null, 
                                                 int? categoryId = null);
    }
}