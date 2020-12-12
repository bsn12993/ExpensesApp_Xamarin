

using ExpensesApp.Interfaces;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(ExpensesApp.Droid.Implementations.Config))]
namespace ExpensesApp.Droid.Implementations
{
    public class Config : IConfig
    {
        private string directoryDB;
        //private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    directoryDB = "";
                }
                return directoryDB;
            }
        }
        /*
        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return platform;
            }
        }
        */
    }
}