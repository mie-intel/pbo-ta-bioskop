using System.Runtime.CompilerServices;
using App.Utils;
using Microsoft.EntityFrameworkCore;
using PBO_GUI;

namespace App
{
    internal class Program
    {
        // Program Utama
        static void Main(string[] args)
        {
            // while (true)
            // {
            //     if (!TerminalDisplay.Display())
            //         break;
            // }
            // string tes = UserProvider.Register("polikarpu123", "mie-mie");
            // Console.WriteLine(tes);
            // Console.WriteLine(FilmProvider.GenerateSeatCode(3));
            FilmProvider.AddFilm("Ipar adalah maut", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            FilmProvider.AddFilm("Ipar2", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            FilmProvider.AddFilm("Ipar3", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            FilmProvider.AddFilm("Ipar4", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            var Seat = FilmProvider.ParseSeat("FPeT3G1");
            // Console.WriteLine(Seat);
            foreach (var p in Seat)
            {
                Console.WriteLine(p.Item1 + " " + p.Item2);
            }
            Console.WriteLine("\nSampai Jumpa!");
        }
    }
}
