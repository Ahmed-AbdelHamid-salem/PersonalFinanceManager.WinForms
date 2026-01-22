using System;
using System.IO;

namespace PersonalFinanceManager.Helpers.Logging
{
    public static class Logger
    {
        public static void LogError(string message)
        {
            File.AppendAllText("ErrorLog.txt", $"{DateTime.Now} : {message}\n");
            File.AppendAllText("ErrorLog.txt", $"==========================\n");
        }
    }
}