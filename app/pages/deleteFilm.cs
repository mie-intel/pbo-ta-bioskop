namespace App.Pages
{
    internal class deleteFilm
    {
        public static void Page()
        {
            Console.Clear();
            Console.WriteLine("Selamat datang di halaman penghapusan film!\n");
            Console.Write("Apakah anda yakin untuk menghapus film ini? (y/n): ");
            string inpConfirm = Console.ReadLine() ?? "";
            if (inpConfirm == "y")
            {
                Console.Write("Masukkan password: ");
                string inpPass = Console.ReadLine() ?? "";
                if (inpPass == "Konfirm") //check pass sama ga sama di db
                    Console.WriteLine("Sukses menghapus film");
                else
                    Console.WriteLine("Gagal menghapus film");
            }
            else
                return;
        }
    }
}
