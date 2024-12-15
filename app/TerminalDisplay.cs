using System.Data.Common;
using System.Text.RegularExpressions;
using App;
using App.Pages;

namespace PBO_GUI
{
    public static class TerminalDisplay
    {
        static string[] routes = { "beranda", "view", "buy", "topup", "addFilm", "deleteFilm" };

        static string currentRoute = "initial";

        static string[] film = { "Ipar adalah maut", "Dilan", "fufufafa" };

        // Menampilkan Command Line
        // Menerima Input dari command line
        public static bool Display()
        {
            if (currentRoute == "initial")
            {
                Console.Clear();
                Console.WriteLine("Mau Login? (L) / Mau Register? (R)");
            }
            Console.WriteLine("Ketik 'exit' untuk keluar.\n");

            // Dapetin command line
            Console.Write("Perintah $ ");
            string inp = Console.ReadLine() ?? ""; // input perintah
            string[] commands = Regex.Split(inp, @"\s+"); // split command, ubah jadi array of string

            // cek current route
            currentRoute = commands[0];

            // keluar program
            if (currentRoute == "exit")
                return false;

            //Login route
            if (currentRoute == "L")
            {
                Program.Login();
            }
            // Register route
            if (currentRoute == "R")
            {
                Program.Register();
            }

            // cek command
            if (currentRoute == "view")
            {
                View.Page(commands[1]);
            }
            else if (currentRoute == "buy")
            {
                Buy.Page(commands[1]);
            }
            else if (currentRoute == "topup")
                TopUp.Page();
            else if (currentRoute == "addFilm")
                addFilm.Page();
            else if (currentRoute == "deleteFilm")
                deleteFilm.Page();
            else
                Beranda.Page();

            return true;
        }
    }
}
