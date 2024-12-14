namespace App.Pages
{
    internal class View
    {
        public static void Page(string id)
        {
            Console.Clear();
            Console.WriteLine("Sedang melihat id " + id);
            Console.WriteLine("++++++++++Detail Film+++++++++");
            Console.WriteLine("Id\t: <id_film>");
            Console.WriteLine("Nama\t: <judulFilm>");
            Console.WriteLine("Tanggal\t: <tanggalFilm>");
            Console.WriteLine("Rate\t: <rateFilm>");
            Console.WriteLine("\nDeskripsi");
            Console.WriteLine(
                "\tLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            );
            Console.WriteLine($"Harga\t: <hargaFilm>");
            Console.WriteLine("Ketik buy <idFilm> untuk membeli.");
        }
    }
}
