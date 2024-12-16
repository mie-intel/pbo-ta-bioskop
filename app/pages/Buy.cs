using App.Model;
using App.Utils;

namespace App.Pages
{
    internal class Buy
    {
        public static string Page(List<string> commands)
        {
            if (commands.Count == 1)
                return "\'buy\' memerlukan 1 parameter <nominalUang>";
            else if (commands.Count != 2)
                return "\'buy\' hanya bisa menerima 1 parameter";

            FilmModel? film = FilmProvider.GetFilmWithId(commands[1]);
            var kursiTersedia = FilmProvider.GetAllSeat(commands[1]);
            if (film == null || kursiTersedia == null)
                return "idFilm tidak valid!";

            Console.Clear();
            Console.WriteLine("Beli film");
            Console.WriteLine();
            Console.WriteLine("Detail Film\n");
            Console.WriteLine($"  Judul   : {film.Nama}");
            Console.WriteLine(
                $"  Harga   : {film.Harga.ToString("C", DBUtil.getCustomCurrency("id-ID"))}"
            );
            Console.WriteLine(
                $"  Saldo   : {UserProvider.GetBalance().ToString("C", DBUtil.getCustomCurrency("id-ID"))}\n"
            );
            Console.WriteLine("Kursi tersedia");
            foreach (var kursi in kursiTersedia)
                Console.WriteLine($"  {kursi[0]} {kursi[1]}");

            // Konfirmasi lanjutan
            string lanjut = IOUtil.GetLine("\nLanjutkan pemesanan?(y/n) ");
            if (!lanjut.ToLower().Equals("y"))
                return "Pesanan dibatalkan";

            if (film.Harga > UserProvider.GetBalance())
                return "Saldo tidak cukup!";

            string kodeKursi = IOUtil.GetLine("Masukkan nomor kursi: ");
            if (!kursiTersedia.Exists(kursi => kursi[0] == kodeKursi))
                return "Nomor kursi tidak valid!";

            string password = IOUtil.GetLine("Masukkan password untuk konfirmasi: ");
            if (UserProvider.VerifyPassword(password).Equals("success")) //check pass sama ga sama di db
            {
                FilmProvider.BookFilm(film.Id, kodeKursi, password);
                return $"Berhasil memesan kursi {kodeKursi}!";
            }
            else
                return "Password salah! Gagal melakukan pemesanan!";
        }
    }
}
