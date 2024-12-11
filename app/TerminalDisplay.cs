using System.Text.RegularExpressions;

namespace PBO_GUI
{
    public static class TerminalDisplay
    {
        static string currentTerminal = "Hello there!";

        public static void DisplayWindow()
        {
            Console.Clear();
            Console.WriteLine(currentTerminal!);
        }

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
