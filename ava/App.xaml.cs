using ava.Helpers;

namespace ava
{
    public partial class App : Application
    {
        private static SQLiteDatabaseHelpers? _db;

        public static SQLiteDatabaseHelpers Db
        {
            get
            {
                if (_db == null)
                {
                    string dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "disciplinas.db3");
                    _db = new SQLiteDatabaseHelpers(dbPath);
                }
                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
