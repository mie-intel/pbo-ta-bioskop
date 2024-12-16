using Microsoft.EntityFrameworkCore;

namespace App.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            User = Set<UserModel>();
            Film = Set<FilmModel>();
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<FilmModel> Film { get; set; }
    }
}
