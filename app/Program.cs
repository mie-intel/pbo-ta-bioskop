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
            Console.WriteLine(FilmProvider.GenerateSeatCode(3));
            Console.WriteLine("\nSampai Jumpa!");
        }
    }
}
