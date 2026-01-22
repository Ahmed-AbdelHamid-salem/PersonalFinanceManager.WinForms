using PersonalFinanceManager.DAL.Data;

namespace PersonalFinanceManager.BLL
{
    public static class StartupService
    {
        public static void InitializeApplication()
        {
            // تهيئة قاعدة البيانات
            DatabaseInitializer.Initialize();
        }
    }
}