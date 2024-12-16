using App.Utils;

namespace App.Pages
{
    internal class DeleteFilm
    {
        public static string Page(List<string> commands)
        {
            if (!(UserProvider.GetStatus() ?? "").Equals("admin"))
                return "Anda tidak diizinkan mengakses perintah ini";

            if (commands.Count == 1)
                return "\'delfilm\' memerlukan 1 parameter <nominalUang>";
            else if (commands.Count != 2)
                return "\'delfilm\' hanya bisa menerima 1 parameter";

            string password = IOUtil.GetLine("Masukkan password untuk konfirmasi: ");
            if (UserProvider.VerifyPassword(password).Equals("success")) //check pass sama ga sama di db
            {
                if (FilmProvider.DeleteFilm(commands[1]) == "success")
                    return "Berhasil menghapus film!";
                else
                    return $"Film dengan id {commands[1]} tidak ditemukan";
            }
            else
                return "Password salah! Gagal menghapus film!";
        }
    }
}
