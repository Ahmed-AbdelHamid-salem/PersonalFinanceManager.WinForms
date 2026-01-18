using System;

namespace PersonalFinanceManager.Core.Models.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CategoryID { get; set; }
        public string Note { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
