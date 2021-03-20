using System;
using Xamarin.Forms;
using System.IO;
using InventoryTracker.Views;

namespace InventoryTracker
{
    public partial class App : Application
    {
        static Database database;
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            DependencyService.Get<INotificationManager>().Initialize();
            CheckLoggedIn();

            MainPage = new NavigationPage(new LoginPage());
        }

        
        public static Database Database
        {
            get
            {
                //Get database, if exists; Create new if not
                if (database == null)
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "InventoryDB.db3")); //Edit this string value to reset database

                return database;
            }
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }

        async public void CheckLoggedIn()
        {
            //Checks if any users are logged in
            var users = await Database.GetUserAsync();

            foreach (var i in users)
            {
                if (i.LoggedIn)
                {
                    IsUserLoggedIn = true;
                    return;
                }
            }
        }
    }
}