using System.IO;
using System;
using Fare;

namespace App.Utils
{
    public class DBUtil
    {
        public static string GetConnectionString(string dbMdf)
        {
            string appPath = Environment.CurrentDirectory;
            string dbPath = Path.Combine(appPath, "db", dbMdf);
            Console.WriteLine("DbPath " + dbPath);
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;";
            return connectionString;
        }

        public static string GetConnectionSQLite(string dbDb)
        {
            string appPath = Environment.CurrentDirectory;
            string dbPath = Path.Combine(appPath, "db", dbDb);
            Console.WriteLine(dbPath);
            // Delete the existing Users.db file if it's corrupted
            // if (File.Exists(dbPath))
            // {
               //  File.Delete(dbPath); // Deleting corrupted file
            // }
            string connectionString = $@"Data Source={dbPath}";
            return connectionString;
        }

        public static string GetRandomString(string regexPattern)
        {
            var xeger = new Xeger(regexPattern, new Random());
            string randomString = xeger.Generate();
            return randomString;
        }
    }
}
