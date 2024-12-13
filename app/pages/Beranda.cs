namespace App.Pages
{
    internal class Beranda
    {
        public static void Page()
        {
            var filmsAvailable = new List<(int No, string ID, string Tanggal, string JudulFilm)>
            {
                (1, "F1234", "Sen, 15 Des 2024", "Mengejar Layang - Layang"),
                (2, "F1235", "Sen, 15 Des 2024", "Ipar adalah Maut - Mantap"),
            };
            string[] username = ["Berau", "Jogja"];
            int saldo = 10000000;

            Console.Clear();
            Console.WriteLine("Selamat datang di aplikasi kami!\n");
            Console.WriteLine($"Hello {username[1]}!");
            Console.WriteLine($"Saldo Tersedia: Rp {saldo}\n");
            Console.WriteLine("Film Tersedia");
            Console.WriteLine("No.\tid\tTanggal\t\t\tJudul Film");
            foreach (var film in filmsAvailable)
            {
                Console.WriteLine($"{film.No}\t{film.ID}\t{film.Tanggal}\t{film.JudulFilm}");
            }
            Console.WriteLine("\nKetik Id Film <idFilm> untuk melihat detail Film.");
        }
    }
}
