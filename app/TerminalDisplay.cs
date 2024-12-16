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

        static string errMessage = "";

        // Menampilkan Command Line
        // Menerima Input dari command line
        public static bool Display()
        {
            if (currentRoute == "initial")
                Beranda.Page();

            if (errMessage != "")
                Console.WriteLine(errMessage);

            // Dapetin command line
            string inp = IOUtil.GetLine("Perintah $ ");
            List<string> commands = Regex.Split(inp, @"\s+").ToList(); // split command, ubah jadi array of string

            // cek current route
            currentRoute = commands[0];

            // keluar program
            if (currentRoute == "exit")
                return false;

            // cek command
            if (currentRoute == "addFilm")
            {
                AddFilm.Page();
                currentRoute = "initial";
            }
            else if (currentRoute == "buy")
            {
                Buy.Page(commands);
                currentRoute = "initial";
            }
            else if (currentRoute == "deleteFilm")
                DeleteFilm.Page();
            else if (currentRoute == "help")
                Help.Page();
            else if (currentRoute == "topup")
            {
                errMessage = TopUp.Page(commands);
                currentRoute = "initial";
            }
            else if (currentRoute == "view")
                View.Page(commands);
            else
            {
                errMessage = (
                    currentRoute == "" ? "" : $"{currentRoute} bukan perintah yang valid!"
                );
                currentRoute = "initial";
            }

            return true;
        }

        public static bool HandleAuth()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("Masuk (L) / Daftar Akun Baru (R) ?");
            string inp = IOUtil.GetLine("Perintah $ ");

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
