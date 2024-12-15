using App.Model;
using App.Utils;

namespace App.Pages
{
    internal class Beranda
    {
        public static void Page()
        {
            List<FilmModel> filmList = FilmProvider.GetAvailableFilm();
            string balance = UserProvider
                .GetBalance()
                .ToString("C", DBUtil.getCustomCurrency("id-ID"));
            string? username = UserProvider.GetUsername();

            Console.Clear();
            Console.WriteLine("Selamat datang di aplikasi kami!\n");
            Console.WriteLine($"Halo {username}!");
            Console.WriteLine($"Saldo Tersedia: {balance}\n");
            Console.WriteLine("Film Tersedia");
            Console.WriteLine($" {"No", -5}{"idFilm", -10}{"Tanggal", -14}Judul");

            int it = 0;
            foreach (var film in filmList)
                Console.WriteLine($" {++it, -5}{film.Id, -10}{film.Tanggal, -14}{film.Nama}");

            Console.WriteLine("\nKetik 'view <idFilm>' melihat detail Film");
        }
    }
}
