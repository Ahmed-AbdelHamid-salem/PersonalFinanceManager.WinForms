namespace PersonalFinanceManager.Core.Models.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int TransactionTypeID { get; set; }
        public bool IsActive { get; set; }
    }
}
