using PersonalFinanceManager.BLL;
using System;
using System.Windows.Forms;

namespace PersonalFinanceManager.UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // تهيئة قاعدة البيانات قبل تشغيل التطبيق
            StartupService.InitializeApplication();

            Application.Run(new Form1());
        }
    }
}
