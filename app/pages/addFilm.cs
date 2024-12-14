namespace App.Pages
{
    internal class addFilm
    {
        public static void Page()
        {
            Console.Clear();
            Console.WriteLine("Selamat datang di halaman penambahan film!\n");
            Console.Write("Judul: ");
            string inpJudul = Console.ReadLine() ?? "";
            Console.Write("Tanggal: ");
            string inpTanggal = Console.ReadLine() ?? "";
            Console.Write("Rate: ");
            string inpRate = Console.ReadLine() ?? "";
            Console.Write("Deskripsi: ");
            string inpDesk = Console.ReadLine() ?? "";
            Console.Write("Massukan password: ");
            string inpPass = Console.ReadLine() ?? "";
            if (inpPass == "Konfirm") //check pass sama ga sama di db
                Console.WriteLine("Sukses menambahkan film");
            else
                Console.WriteLine("Gagal menambahkan film");
        }
    }
}
