using App.Terminal;

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

            Console.WriteLine("\nSampai Jumpa!");
        }
    }
}
