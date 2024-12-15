using System;
using System.Data.Common;
using System.Text.RegularExpressions;
using App;
using App.Pages;
using App.Utils;

namespace App.Terminal
{
    public static class TerminalDisplay
    {
        static string[] routes = { "beranda", "view", "buy", "topup", "addFilm", "deleteFilm" };

        static string currentRoute = "initial";

        static string message = "";

        // Menampilkan Command Line
        // Menerima Input dari command line
        public static bool Display()
        {
            if (currentRoute == "initial")
                Beranda.Page();

            if (message != "")
                Console.WriteLine(message);

            // Dapetin command line
            Console.Write("Perintah $ ");
            string inp = Console.ReadLine() ?? ""; // input perintah
            List<string> commands = Regex.Split(inp, @"\s+").ToList(); // split command, ubah jadi array of string

            // cek current route
            currentRoute = commands[0];

            // keluar program
            if (currentRoute == "exit")
                return false;

            // cek command
            if (currentRoute == "view")
            {
                View.Page(commands);
            }
            else if (currentRoute == "buy")
                Buy.Page(commands);
            else if (currentRoute == "topup")
                TopUp.Page();
            else if (currentRoute == "addFilm")
                addFilm.Page();
            else if (currentRoute == "deleteFilm")
                deleteFilm.Page();
            else
                currentRoute = "initial";

            return true;
        }

        public static bool HandleAuth()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("Masuk (L) / Daftar Akun Baru (R) ?");
            Console.Write("Perintah $ ");
            string inp = Console.ReadLine()?.Trim() ?? "";

            // defines path
            if (inp.Equals("R", StringComparison.OrdinalIgnoreCase))
                return AuthProvider.HandleRegister();
            else if (inp.Equals("L", StringComparison.OrdinalIgnoreCase))
                return AuthProvider.HandleLogin();
            else
            {
                Console.WriteLine("\nMasukan tidak valid!. Gagal masuk!");
                return false;
            }
        }
    }
}
