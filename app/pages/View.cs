using App.Model;
using App.Utils;

namespace App.Pages
{
    internal class View
    {
        public static string Page(List<string> commands)
        {
            Console.Clear();
            if (commands.Count == 1)
                return "\'view\' memerlukan paramter <idFilm> untuk bekerja! Ketik \'help\' untuk bantuan";
            else if (commands.Count > 2)
                return "view memerlukan tepat 1 parameter <idFilm>. Ketik \'help\' untuk bantuan";

            FilmModel? film = FilmProvider.GetFilmWithId(commands[1]);

            if (film == null)
                return "idFilm tidak valid!";

            Console.WriteLine("Detail Film\n");
            Console.WriteLine($"Judul   : {film.Nama}");
            Console.WriteLine($"Id      : {film.Id}");
            Console.WriteLine($"Rating  : {new string('\u2605', film.Rate)}");
            Console.WriteLine(
                $"Harga   : {film.Harga.ToString("C", DBUtil.getCustomCurrency("id-ID"))}"
            );

            Console.WriteLine("\nSinopsis: ");
            IOUtil.WriteParagraph(film.Deskripsi);

            Console.WriteLine('\n');
            Console.WriteLine("Ketik \'buy\' <idFilm> untuk memesan tiket");
            Console.WriteLine("Tekan \'enter\' untuk kembali ke beranda");
            return "";
        }
    }
}
