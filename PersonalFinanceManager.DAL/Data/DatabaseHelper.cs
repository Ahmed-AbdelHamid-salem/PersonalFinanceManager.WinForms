using PersonalFinanceManager.Helpers.Logging;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace PersonalFinanceManager.DAL.Data
{
    public class DatabaseHelper
    {
        private readonly string _dbFile;
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _dbFile = "finance.db";
            _connectionString = $"Data Source={_dbFile};Version=3;";

            if (!File.Exists(_dbFile))
                SQLiteConnection.CreateFile(_dbFile);
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        #region ExecuteNonQuery
        public int ExecuteNonQuery(string query, SQLiteParameter[] parameters = null)
        {
            try
            {
                using (SQLiteConnection con = GetConnection())
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (SQLiteException ex)
            {
                Logger.LogError($"Error while ExecuteNonQuery: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region ExecuteScalar
        public object ExecuteScalar(string query, SQLiteParameter[] parameters = null)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(_connectionString))
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error while ExecuteScalar: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region GetTable
        public DataTable GetTable(string query, SQLiteParameter[] parameters = null)
        {
            try
            {
                using (SQLiteConnection con = GetConnection())
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error while execute (GetTable) method: {ex.Message}");
                throw;
            }
        }
        #endregion

        #region TableHasRows
        public bool TableHasRows(string query, SQLiteParameter[] parameters = null)
        {
            DataTable dt = GetTable(query, parameters);
            return dt.Rows.Count > 0;
        }
        #endregion
    }
}
