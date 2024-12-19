using App.Utils;

namespace App.Pages
{
    internal class Help
    {
        // <namaCommand>, <penjelasan>, <>
        private static List<(
            string command,
            string? parameters,
            string? type,
            string penjelasan
        )> defaultCommands = new List<(string, string?, string?, string)>
        {
            ("buy", "[idFilm]", "(str)", "Memesan tiket film dengan id [idFilm]"),
            ("help", null, null, "Mendapatkan dokumentasi aplikasi"),
            ("ticket", null, null, "Melihat semua tiket yang telah dipesan"),
            (
                "topup",
                "[uang]",
                "(int)",
                "Menambahkan saldo sebanyak <uang> ke dalam akun pengguna"
            ),
            ("view", "<idFilm>", "(str)", "Melihat detail dari film dengan id [idFilm]"),
        };

        private static List<(
            string command,
            string? parameters,
            string? type,
            string penjelasan
        )> adminCommands = new List<(string, string?, string?, string)>
        {
            ("addfilm", null, null, "Menambahkan film baru"),
            ("delfilm", "[idFilm]", "(str)", "Menghapus film dengan id [idFilm]"),
        };

        public static string Page()
        {
            Console.Clear();
            Console.WriteLine("Bantuan\n");
            Console.WriteLine($" {"Perintah", -11}{"Params", -11}{"Tipe", -8}Penjelasan");

            List<(string command, string? parameters, string? type, string penjelasan)> commands = (
                UserProvider.GetStatus() == "default" ? defaultCommands : adminCommands
            );

            foreach (var command in commands)
                Console.WriteLine(
                    $" {command.Item1, -11}{command.Item2 ?? "-", -11}{command.Item3 ?? "-", -8}{command.Item4}"
                );

            Console.WriteLine();
            Console.WriteLine("Tekan \'enter\' untuk kembali ke beranda");
            return "";
        }
    }
}
