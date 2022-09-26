namespace Singleton_Design_Pattern_CSharp_AspNetCore_Example.Services
{
    public class DatabaseService
    {
        private DatabaseService()
        {
            Console.WriteLine($"{nameof(DatabaseService)} is created.");
        }
        static DatabaseService _databaseService;
        public static DatabaseService GetInstance
        {
            get
            {
                if (_databaseService == null)
                    _databaseService = new DatabaseService();

                return _databaseService;
            }
        }

        public int Count { get; set; }
        public bool Connection()
        {
            Count++;
            Console.WriteLine("Bağlantı sağlandı...");
            return true;
        }
        public bool Disconnect()
        {
            Console.WriteLine("Bağlantı koparıldı...");
            return true;
        }
    }
}
