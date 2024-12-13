using System.Runtime.CompilerServices;
using PBO_GUI;

namespace app
{
    internal class Program
    {
        // Program Utama
        static void Main(string[] args)
        {
            // Inisialisasi database
            // 1. login dulu
            //      kalo gagal, return null
            //      kalo berhasil, lanjut
            // kao gagal login / register -> return

            // program utama
            while (true)
            {
                bool lanjut = TerminalDisplay.Display();
                if (!lanjut)
                    break;
            }

            Console.WriteLine("\nSampai Jumpa!");
        }
    }
}
