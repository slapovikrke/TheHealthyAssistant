using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using TheHealthyAssistant.Data;

namespace TheHealthyAssistant
{
    public partial class App : Application
    {
        static UserDatabase database;

        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new UserDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3"));
                }
                return database;
            }
        }
        //public static string FolderPath { get; private set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage (new TheHealthyAssistant.MainPage());
            //FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
           
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
