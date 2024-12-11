using System.Text.RegularExpressions;

namespace PBO_GUI
{
    public static class TerminalDisplay
    {
        // berisi isi dari terminal utama
        static string currentTerminal = "Hello there!";

        // Menampilkan Terminal Utama
        public static void DisplayWindow()
        {
            Console.Clear();
            Console.WriteLine(currentTerminal!);
        }

        // Menampilkan Command Line
        // Menerima Input dari command line
        public static void DisplayCommand()
        {
            Console.Write("Perintah $ ");
            string inp = Console.ReadLine() ?? "";
            int itr = 1;
            string[] commands = Regex.Split(inp, @"\s+");
            foreach (string command in commands)
            {
                Console.WriteLine(itr.ToString() + command);
                itr += 1;
            }
        }
    }
}
