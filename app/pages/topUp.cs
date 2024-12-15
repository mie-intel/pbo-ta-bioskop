namespace App.Pages
{
    internal class TopUp
    {
        public static string Page()
        {
            int saldo = 2000;
            Console.Clear();
            Console.WriteLine("Selamat datang di halaman top-up!\n");
            Console.Write("Ketik nominal top-up: ");
            int topup = int.Parse(Console.ReadLine() ?? ""); // Baca input topup
            Console.Write("Masukkan password: ");
            string inpPass = Console.ReadLine() ?? "";
            if (inpPass == "Konfirm") // cek juga apakah password sama kek yang ada di database
            {
                saldo += topup;
                Console.WriteLine($"\nBerhasil melakukan top-up.\nSaldo anda saat ini: {saldo}");
                Console.WriteLine("\nKetik 'buy' untuk melanjutkan pembelian tiket.");
                string inpBuy = Console.ReadLine() ?? ""; // tunggu input user
                if (inpBuy == "buy")
                {
                    Buy.Page([]);
                }
                return "Berhasil melakukan top up!";
            }
            else
            {
                Console.WriteLine("Password salah");
                return "Gagal melakukan Top Up";
            }
        }
    }
}
