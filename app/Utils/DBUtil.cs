using System.IO;

namespace App.Utils
{
    public class DBUtil
    {
        public static string GetConnectionString(string dbMdf)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(appPath, "db", dbMdf);
            string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30;";
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
