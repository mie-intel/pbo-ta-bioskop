using App.Terminal;
using App.Utils;

namespace App
{
    internal class Program
    {
        // Program Utama
        static void Main(string[] args)
        {
            if (!TerminalDisplay.HandleAuth())
                return;

            while (true)
                if (!TerminalDisplay.Display())
                    break;

            UserProvider.LogOut();
            Console.WriteLine("\nBerhasil logout. Sampai Jumpa!");
        }
    }
}
