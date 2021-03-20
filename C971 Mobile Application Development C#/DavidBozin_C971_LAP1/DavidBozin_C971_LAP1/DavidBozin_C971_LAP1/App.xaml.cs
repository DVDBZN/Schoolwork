using System;
using Xamarin.Forms;
using System.IO;

namespace DavidBozin_C971_LAP1
{
    public partial class App : Application
    {
        static Database database;

        public App()
        {
            InitializeComponent();
            DependencyService.Get<INotificationManager>().Initialize();
            MainPage = new NavigationPage(new MainPage());
        }

        public static Database Database
        {
            get
            {
                if (database == null)
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WGUTrackerDB.db3"));

                return database;
            }
        }

        protected override void OnStart(){}
        protected override void OnSleep(){}
        protected override void OnResume(){}
    }
}