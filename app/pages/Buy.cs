using PBO_GUI;

namespace App.Pages
{
    internal class Buy
    {
        public static void Page(string id)
        {
            var kursiTersedia = new List<(string No, string Status)>
            {
                ("A21", "TELAH DIPESAN"),
                ("A23", "..."),
                ("A43", "TELAH DIPESAN"),
                ("A23", "TELAH DIPESAN"),
                ("A23", "TELAH DIPESAN"),
            };
            int hargaFilm = 200000;
            int saldo = 10000;

            Console.Clear();
            Console.WriteLine("Selamat datang di halaman pembelian tiket Film dengan id " + id);
            Console.WriteLine("\nBeli Tiket Film <Judul Film>");
            Console.WriteLine("Harga Film\t: <harga Film>");
            Console.WriteLine("Saldo\t\t: <Jumlah saldo>");
            Console.WriteLine("\nKursi tersedia");
            Console.WriteLine("No\t Status\t");
            foreach (var kursi in kursiTersedia)
            {
                Console.WriteLine($"{kursi.No}\t {kursi.Status}");
            }

            // cek apakah saldo cukup untuk membeli tiket
            if (saldo >= hargaFilm)
            {
                Console.Write("\nMasukkan No kursi: ");
                string inpNoKursi = Console.ReadLine() ?? ""; //perlu dicek ga ini kalo kursi yang dipilih keisi?
                Console.Write("Masukkan Password: ");
                string inpPass = Console.ReadLine() ?? "";
                if (inpPass == "Konfirmasi") //perlu cek pass sama ga sama yang di database
                {
                    Console.WriteLine("\nSukses memesan tiket");
                }
            }
            else if (saldo <= hargaFilm)
            {
                Console.WriteLine("\nSaldo tidak cukup, silahkan Top-Up terlebih dahulu.");
                Console.Write("Apakah anda ingin Top-Up? (y/n)\n");
            }
            else
            {
                Console.WriteLine("Gagal memesan tiket");
            }
        }
    }
}
