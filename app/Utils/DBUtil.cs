using System;
using System.IO;
using Fare;

namespace App.Utils
{
    public class DBUtil
    {
        // Connect the app with the Sql Server Database
        public static string GetConnectionString(string dbMdf)
        {
            string appPath = Environment.CurrentDirectory;
            string dbPath = Path.Combine(appPath, "db", dbMdf);
            string connectionString =
                $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;";
            return connectionString;
        }

        // Connect the app with the SQLite Database
        public static string GetConnectionSQLite(string dbDb)
        {
            string appPath = Environment.CurrentDirectory;
            string dbPath = Path.Combine(appPath, "db", dbDb);
            Console.WriteLine("Connect db: " + dbPath);
            string connectionString = $@"Data Source={dbPath}";
            return connectionString;
        }

        // Build a random string base on regex pattern
        public static string GetRandomString(string regexPattern)
        {
            var xeger = new Xeger(regexPattern, new Random());
            string randomString = xeger.Generate();
            return randomString;
        }
    }
}
