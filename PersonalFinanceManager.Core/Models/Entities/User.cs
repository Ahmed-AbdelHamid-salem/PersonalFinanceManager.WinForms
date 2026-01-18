using System;

namespace PersonalFinanceManager.Core.Models.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string HashPassword { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
