using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Utils
{
    internal class UserProvider
    {
        private static string _username = null;
        private static string _password = null;

        // Creates a database context
        private static UserDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            // optionsBuilder.UseSqlServer(DBUtil.GetConnectionString("Users.Mdf"));
            optionsBuilder.UseSqlite(DBUtil.GetConnectionSQLite("Users.db"));

            return new UserDbContext(optionsBuilder.Options);
        }

        private static string GetUserId()
        {
            return DBUtil.GetRandomString(@"U[0-9A-Za-z]{6}");
        }


        public static string LogIn(string username, string password)
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            var user = dbContext.User.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                _username = username;
                _password = password;
                return "success";
            }
            return "invalid";
        }

        public static string Register(string username, string password)
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();

            // Check if the user already exists
            if (dbContext.User.Any(u => u.Username == username))
            {
                return "user-exist";
            }

            // Add the new user
            var newUser = new UserModel { Id = GetUserId(), Username = username, Password = password };
            dbContext.User.Add(newUser);
            dbContext.SaveChanges();
            return "success";
        }

        public static string GetUsername()
        {
            return _username;
        }

        public static string Verify(string password)
        {
            return _password == password ? "success" : "failed";
        }

        public static void LogOut()
        {
            _username = null;
            _password = null;
        }
    }

    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<UserModel> User { get; set; }
    }
}
