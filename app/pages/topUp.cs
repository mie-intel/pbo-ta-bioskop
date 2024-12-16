using App.Utils;

namespace App.Pages
{
    internal class TopUp
    {
        public static string Page(List<string> commands)
        {
            if (commands.Count == 1)
                return "\'topup\' memerlukan 1 parameter <nominalUang>";
            else if (commands.Count != 2)
                return "\'topup\' hanya bisa menerima 1 parameter";
            else if (!int.TryParse(commands[1], out int uang))
                return "Parameter \'topup\' hanya dapat berupa bilangan bulat!";

            string password = IOUtil.GetLine("Masukkan password untuk konfirmasi: ");
            if (UserProvider.VerifyPassword(password).Equals("success")) //check pass sama ga sama di db
            {
                int uang = int.Parse(commands[1]);
                UserProvider.TopUp(uang);
                return "Berhasil melakukan top up!";
            }
            else
                return "Gagal melakukan top up! Password salah";
        }
    }
}
