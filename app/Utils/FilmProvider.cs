using App.Model;
using Microsoft.EntityFrameworkCore;

namespace App.Utils
{
    internal class FilmProvider
    {
        // Creates a database context
        private static FilmDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmDbContext>();
            optionsBuilder.UseSqlite(DBUtil.GetConnectionSQLite("Films.db"));
            return new FilmDbContext(optionsBuilder.Options);
        }

        // Get Film ID
        private static string GetFilmId()
        {
            return DBUtil.GetRandomString(@"F[0-9A-Za-z]{6}");
        }

        // Get Seat Code in the form of ,,,,
        public static string GenerateSeatCode(int seat)
        {
            string result = "";
            while (--seat > 0)
                result += ",";
            return result;
        }

        // Book Film
        public static string BookFilm(string filmId, string seat)
        {
            return "NULL";
        }

        // Parsing Seat Code from Database
        public static List<(string, string)>? ParseSeat(string filmId)
        {
            // The format will be A1, A2, A3, ...
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            var selectedFilm = dbContext.Film.FirstOrDefault(u => u.Id == filmId);

            // Kalo kosong, gagal
            if (selectedFilm == null)
                return null;

            string[] SeatDbList = selectedFilm.Seat.Split(',');
            List<(string seatCode, string userCode)> SeatList =
                new List<(string seatCode, string userCode)>();

            for (int i = 0; i < SeatDbList.Length; i += 1)
            {
                string code = "A" + (i + 1).ToString("D2");
                string status = SeatDbList[i] == "" ? "." : "BOOKED";
                SeatList.Add((code, status));
            }
            return SeatList;
        }

        // Function to add new film
        // Admin only
        public static string AddFilm(
            string nama,
            string tanggal,
            int rate,
            int harga,
            int seat,
            string deskripsi
        )
        {
            // Admin only
            // if (UserProvider.GetStatus() != "admin")
            //     return "not-allowed";

            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();

            // Check if the film already exist
            if (dbContext.Film.Any(u => u.Nama == nama && u.Tanggal == tanggal))
                return "film-exist";

            // Add new film
            var newFilm = new FilmModel
            {
                Id = GetFilmId(),
                Nama = nama,
                Tanggal = tanggal,
                Rate = rate,
                Harga = harga,
                Seat = GenerateSeatCode(seat),
                Deskripsi = deskripsi,
            };
            dbContext.Film.Add(newFilm);
            dbContext.SaveChanges();
            return "success";
        }

        // Remove Film
        public static string DeleteFilm(string filmId)
        {
            // Admin only
            if (UserProvider.GetStatus() != "admin")
                return "not-allowed";

            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();

            var selectedFilm = dbContext.Film.FirstOrDefault(u => u.Id == filmId);

            // remove film if it exist
            if (selectedFilm != null)
                dbContext.Film.Remove(selectedFilm);
            else
                return "not-found";
            return "success";
        }
    }

    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options)
            : base(options)
        {
            Film = Set<FilmModel>();
        }

        public DbSet<FilmModel> Film { get; set; }
    }
}
