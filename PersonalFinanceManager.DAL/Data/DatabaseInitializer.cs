using PersonalFinanceManager.Helpers.Security;
using System;
using System.Data.SQLite;

namespace PersonalFinanceManager.DAL.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize()
        {
            CreateTables();
            SeedData();
        }

        #region Create Tables
        private static void CreateTables()
        {
            string usersTable = @"
                CREATE TABLE IF NOT EXISTS Tbl_Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    HashPassword TEXT NOT NULL,
                    IsActive INTEGER NOT NULL,
                    CreatedAt TEXT NOT NULL
                );";

            string transactionTypesTable = @"
                CREATE TABLE IF NOT EXISTS Tbl_TransactionTypes (
                    TransactionTypeID INTEGER PRIMARY KEY,
                    TransactionTypeName TEXT NOT NULL
                );";

            string categoriesTable = @"
                CREATE TABLE IF NOT EXISTS Tbl_Categories (
                    CategoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                    CategoryName TEXT NOT NULL,
                    TransactionTypeID INTEGER NOT NULL,
                    IsActive INTEGER NOT NULL,
                    FOREIGN KEY(TransactionTypeID) REFERENCES Tbl_TransactionTypes(TransactionTypeID)
                );";

            string transactionsTable = @"
                CREATE TABLE IF NOT EXISTS Tbl_Transactions (
                    TransactionID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Amount REAL NOT NULL,
                    TransactionDate TEXT NOT NULL,
                    CategoryID INTEGER NOT NULL,
                    Note TEXT,
                    CreatedByUserID INTEGER NOT NULL,
                    CreatedAt TEXT NOT NULL,
                    FOREIGN KEY(CategoryID) REFERENCES Tbl_Categories(CategoryID),
                    FOREIGN KEY(CreatedByUserID) REFERENCES Tbl_Users(UserID)
                );";

            DatabaseHelper.ExecuteNonQuery(usersTable);
            DatabaseHelper.ExecuteNonQuery(transactionTypesTable);
            DatabaseHelper.ExecuteNonQuery(categoriesTable);
            DatabaseHelper.ExecuteNonQuery(transactionsTable);
        }
        #endregion

        #region Seed Data
        private static void SeedData()
        {
            SeedTransactionTypes();
            SeedAdminUser();
        }
        #endregion

        #region Seed Transaction Types
        private static void SeedTransactionTypes()
        {
            string seedTypes = @"
                INSERT OR IGNORE INTO Tbl_TransactionTypes
                (TransactionTypeID, TransactionTypeName)
                VALUES
                (1, 'Income'),
                (2, 'Expense');";

            DatabaseHelper.ExecuteNonQuery(seedTypes);
        }
        #endregion

        #region Seed Admin User
        private static void SeedAdminUser()
        {
            string checkAdminQuery = @"
                SELECT COUNT(*)
                FROM Tbl_Users
                WHERE Username = 'admin';";

            object result = DatabaseHelper.ExecuteScalar(checkAdminQuery);

            if (Convert.ToInt32(result) > 0)
                return; // Admin already exists

            string hashedPassword = PasswordHasher.Hash("admin");

            string insertAdminQuery = @"
                INSERT INTO Tbl_Users
                (Username, HashPassword, IsActive, CreatedAt)
                VALUES
                (@Username, @HashPassword, @IsActive, @CreatedAt);";

            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@Username", "admin"),
                new SQLiteParameter("@HashPassword", hashedPassword),
                new SQLiteParameter("@IsActive", 1),
                new SQLiteParameter("@CreatedAt",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            DatabaseHelper.ExecuteNonQuery(insertAdminQuery, parameters);
        }
        #endregion
    }
}
