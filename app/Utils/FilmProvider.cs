using App.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace App.Utils
{
    internal class FilmProvider
    {
        // Creates a database context
        private static AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(DBUtil.GetConnectionSQLite("Films.db"));
            return new AppDbContext(optionsBuilder.Options);
        }

        // Get Film ID
        private static string GetFilmId()
        {
            return DBUtil.GetRandomString(@"F[0-9A-Za-z]{4}");
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
        public static string BookFilm(string filmId, string seatCode, string password)
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();

            // get current film information
            var selectedFilm = dbContext.Film.FirstOrDefault(u => u.Id == filmId);
            if (selectedFilm == null)
                return "not-found";

            // get current user information
            var currentUser = UserProvider.GetCurrentUser();
            if (currentUser == null)
                return "user-error";

            // Proses memesan
            string[] seatList = selectedFilm.Seat.Split(',');
            bool matched = false;
            for (int i = 0; i < seatList.Length; ++i)
            {
                string code = "A" + (i + 1).ToString("D2");
                if (code != seatCode)
                    continue;
                if (seatList[i] != "")
                    return "already-booked";
                matched = true;
                seatList[i] = currentUser.Id;
            }

            if (!matched)
                return "error";

            // Simpan hasil
            selectedFilm.Seat = string.Join(",", seatList);
            dbContext.SaveChanges();

            // Melakukan pembelian
            UserProvider.UseMoney(selectedFilm.Harga);

            return "success";
        }

        // Parsing Seat Code from Database
        public static List<List<string>>? GetAllSeat(string filmId)
        {
            // The format will be A1, A2, A3, ...
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            var selectedFilm = dbContext.Film.FirstOrDefault(u => u.Id == filmId);

            // Kalo kosong, gagal
            if (selectedFilm == null)
                return null;

            string[] SeatDbList = selectedFilm.Seat.Split(',');
            List<List<string>> SeatList = [];

            for (int i = 0; i < SeatDbList.Length; i += 1)
            {
                string code = "A" + (i + 1).ToString("D2");
                string status = SeatDbList[i] == "" ? "TERSEDIA" : ".";
                SeatList.Add([code, status]);
            }
            /*
                Format List
                [code, status],
                [code, status],
                ....
            */
            return SeatList;
        }

        // Menegeluarkan  list semua film yang tersedia
        public static List<FilmModel> GetAvailableFilm()
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            var result = dbContext.Film.ToList() ?? []; // Ubah ke bentuk list
            return result;
        }

        // Mendapatkan data lengkap sebuah film
        public static FilmModel? GetFilmWithId(string filmId)
        {
            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
            return dbContext.Film.FirstOrDefault(u => u.Id == filmId) ?? null;
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
            // if (UserProvider.GetStatus() != "admin")
            //     return "not-allowed";

            var dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();

            var selectedFilm = dbContext.Film.FirstOrDefault(u => u.Id == filmId);

            // if not found, continue
            if (selectedFilm == null)
                return "not-found";

            dbContext.Film.Remove(selectedFilm);
            dbContext.SaveChanges();
            return "success";
        }
    }
}
