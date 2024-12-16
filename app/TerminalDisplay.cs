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
        static string currentRoute = "beranda";
        static string errMessage = "";

        // Menampilkan Command Line
        // Menerima Input dari command line
        public static bool Display()
        {
            if (currentRoute == "beranda")
                Beranda.Page();

            if (errMessage != "")
                Console.WriteLine(errMessage);
            errMessage = "";

            // Dapetin command line
            string inp = IOUtil.GetLine("Perintah $ ");
            List<string> commands = Regex.Split(inp, @"\s+").ToList(); // split command, ubah jadi array of string

            // cek current route
            currentRoute = commands[0];

            // keluar program
            if (currentRoute == "exit")
                return false;

            // cek command
            if (currentRoute == "addfilm")
            {
                errMessage = AddFilm.Page();
                currentRoute = "beranda";
            }
            else if (currentRoute == "buy")
            {
                errMessage = Buy.Page(commands);
                currentRoute = "beranda";
            }
            else if (currentRoute == "delfilm")
            {
                errMessage = DeleteFilm.Page(commands);
                currentRoute = "beranda";
            }
            else if (currentRoute == "help")
                Help.Page();
            else if (currentRoute == "topup")
            {
                errMessage = TopUp.Page(commands);
                currentRoute = "beranda";
            }
            else if (currentRoute == "ticket")
                Tickets.Page();
            else if (currentRoute == "view")
            {
                errMessage = View.Page(commands);
                if (errMessage != "")
                    currentRoute = "beranda";
            }
            else
            {
                errMessage = (
                    currentRoute == "" ? "" : $"\'{currentRoute}\' bukan perintah yang valid!"
                );
                currentRoute = "beranda";
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
