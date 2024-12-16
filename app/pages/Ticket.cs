using App.Model;
using App.Utils;

namespace App.Pages
{
    internal class Tickets
    {
        public static void Page()
        {
            List<List<string>>? tickets = FilmProvider.ViewTicket();

            Console.Clear();
            Console.WriteLine("Tiket Saya");

            if (tickets == null)
                Console.WriteLine("Belum memesan tiket. Pesan sekarang!");
            else
            {
                foreach (var ticket in tickets)
                {
                    Console.WriteLine($"\n  {"Judul", -8}: {ticket[0]}");
                    Console.WriteLine($"  {"Tanggal", -8}: {ticket[1]}");
                    Console.WriteLine($"  {"Kursi", -8}: {ticket[2]}");
                }
            }

            Console.WriteLine("\nTekan \'enter\' untuk kembali ke beranda");
        }
    }
}
