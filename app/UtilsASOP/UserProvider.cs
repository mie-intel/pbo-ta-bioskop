using App.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Utils
{
    internal class UserProvider
    {
        private static string? _username = null,
            _password = null,
            _status = null;
        private static int _balance = 0;

        // Creates a database context
        private static AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(DBUtil.GetConnectionSQLite("Users.db"));
            return new AppDbContext(optionsBuilder.Options);
        }

        // Update amount of money
        private static void SyncBalance()
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            var selectedUser = dbContext.User.FirstOrDefault(u =>
                u.Username == _username && u.Password == _password
            );

            if (selectedUser == null)
                return;

            selectedUser.Balance = _balance;
            dbContext.SaveChanges();
        }

        public static UserModel? GetCurrentUser()
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            return dbContext.User.FirstOrDefault(u =>
                u.Username == _username && u.Password == _password
            );
        }

        // Get current username
        public static string? GetUsername()
        {
            return _username;
        }

        public static string? GetStatus()
        {
            return _status;
        }

        public static int GetBalance()
        {
            return _balance;
        }

        public static string TopUp(int amount)
        {
            _balance += amount;
            SyncBalance();
            return "success";
        }

        public static string UseMoney(int amount)
        {
            if (_balance < amount)
                return "not-enough";

            _balance -= amount;
            SyncBalance();

            return "success";
        }

        // Get User ID
        private static string GetUserId()
        {
            return DBUtil.GetRandomString(@"U[0-9A-Za-z]{4}");
        }

        // Login to the current existing account
        public static string LogIn(string username, string password)
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            var user = dbContext.User.SingleOrDefault(u =>
                u.Username == username && u.Password == password
            );
            if (user != null)
            {
                _username = user.Username;
                _password = user.Password;
                _status = user.Status;
                _balance = user.Balance;
                return "success";
            }
            return "invalid";
        }

        // Create new account
        public static string Register(string username, string password)
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();

            // Check if the user already exists
            if (dbContext.User.Any(u => u.Username == username))
                return "user-exist";

            // Add the new user
            var newUser = new UserModel
            {
                Id = GetUserId(),
                Username = username,
                Password = password,
                Status = "default",
                Balance = 0,
            };
            dbContext.User.Add(newUser);
            dbContext.SaveChanges();
            return "success";
        }

        // Verify password
        public static string VerifyPassword(string password)
        {
            return _password == password ? "success" : "failed";
        }

        // LogOut from application
        public static void LogOut()
        {
            _username = null;
            _password = null;
            _status = null;
        }
    }
}
