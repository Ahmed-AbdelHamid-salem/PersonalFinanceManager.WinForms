using PersonalFinanceManager.DAL.Data;

namespace PersonalFinanceManager.BLL
{
    public static class StartupService
    {
        private static readonly DatabaseInitializer _databaseInitializer = new DatabaseInitializer();

        public static void InitializeApplication()
        {
            // تهيئة قاعدة البيانات
            _databaseInitializer.Initialize();
        }
    }
}