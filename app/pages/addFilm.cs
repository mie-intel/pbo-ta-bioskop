namespace App.Pages
{
    internal class addFilm
    {
        public static void Page()
        {
            Console.Clear();
            Console.WriteLine("Selamat datang di halaman penambahan film!\n");
            Console.WriteLine("Judul: <judulFilm>");
            Console.WriteLine("Tanggal: <tanggalFilm>");
            Console.WriteLine("Rate: <1-5>");
            Console.WriteLine("Deskripsi: <masukkanDeskripsi>");
            Console.WriteLine("Massukan password: <password>");
            Console.WriteLine("[MESSAGE]: Sukses menambahkan film / Gagal menambahkan film");
        }
    }
}
