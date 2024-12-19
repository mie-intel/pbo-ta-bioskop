using System;
using App.Utils;
using PBO_IOUtils;

namespace App.Pages
{
    internal class AddFilm
    {
        public static string Page()
        {
            if (!(UserProvider.GetStatus() ?? "").Equals("admin"))
                return "Anda tidak diizinkan mengakses perintah ini";

            Console.Clear();
            Console.WriteLine("Tambahkan film baru!\n");
            string nama = IOUtil.GetLine($" {"Judul", 10}: ");
            string tanggal = IOUtil.GetLine($" {"Tanggal", 10}: ");
            int rate = IOUtil.GetInt($" {"Rating", 10}: ");
            int harga = IOUtil.GetInt($" {"Harga", 10}: ");
            int seat = IOUtil.GetInt($" {"Kursi", 10}: ");
            string deskripsi = IOUtil.GetLine($" {"Deskripsi", 10}: ");
            Console.WriteLine("");
            string password = IOUtil.GetLine("Masukkan password untuk konfirmasi: ");
            if (
                nama == ""
                || tanggal == ""
                || rate == -1
                || harga == -1
                || seat == -1
                || deskripsi == ""
            )
                return "Gagal menambahkan film. Data tidak boleh kosong!";

            if (UserProvider.VerifyPassword(password).Equals("success")) //check pass sama ga sama di db
            {
                FilmProvider.AddFilm(nama, tanggal, rate, harga, seat, deskripsi);
                return "Berhasil menambahkan film";
            }
            else
                return "Password salah! Gagal menambahkan film!";
        }
    }
}
